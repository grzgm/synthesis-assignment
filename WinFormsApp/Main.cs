using DataAccessLayer;
using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Managers;
using LogicLayer.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System.Security.Principal;
using System.Text.RegularExpressions;

namespace WinFormsApp
{
    public partial class Main : Form
    {
        IItemRepository itemRepository;
        IItemManager itemManager;
        IItemCategoryRepository itemCategoryRepository;
        IItemCategoryManager itemCategoryManager;

        List<ItemCategory> itemCategories;
        List<ItemCategory> itemSubCategories;
        List<Item> items;
        Item selectedItem;

        public Main()
        {
            itemRepository = new ItemRepository();
            itemManager = new ItemManager(itemRepository);
            itemCategoryRepository = new ItemCategoryRepository();
            itemCategoryManager = new ItemCategoryManager(itemCategoryRepository);

            (itemCategories, itemSubCategories) = itemCategoryManager.ReadAllItemCategories();

            InitializeComponent();

            List<ItemCategory> cbCategorySearchList = new List<ItemCategory>(itemCategories);
            cbCategorySearchList.Insert(0, new ItemCategory(0, ""));
            cbCategorySearch.DataSource = cbCategorySearchList;
            cbCategoryDetails.DataSource = new List<ItemCategory>(itemCategories);
            cbCategoryCreator.DataSource = new List<ItemCategory>(itemCategories);


            items = itemManager.ReadItems();
        }

        private void btnItemSearch_Click(object sender, EventArgs e)
        {

            DisableItemDetailsGroup();

            items = null;

            int itemId;

            // input Id validation
            if (tbIdSearch.Text != "")
            {
                try
                {
                    itemId = int.Parse(tbIdSearch.Text);
                    if (itemId <= 0)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Id must be intiger bigger than 0");
                    return;
                }
            }
            else
            {
                itemId = 0;
            }

            string itemName = tbNameSearch.Text;
            ItemCategory itemCategory = (ItemCategory)cbCategorySearch.SelectedValue;
            ItemCategory itemSubCategory = (ItemCategory)cbSubCategorySearch.SelectedValue;
            if (itemCategory.Id == 0)
            {
                itemCategory = null;
                itemSubCategory = null;
            }

            // input Price validation
            decimal itemPrice;
            if (tbPriceCreator.Text != "")
            {
                try
                {
                    itemPrice = decimal.Parse(tbPriceCreator.Text);
                    if (itemPrice <= 0)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Id must be intiger bigger than 0");
                    return;
                }
            }
            else
            {
                itemPrice = 0;
            }

            bool itemAvailable = cbAvailableCreator.Checked;

            if (itemId > 0)
            {
                items = new List<Item>() { itemManager.ReadItem(itemId, itemName, itemCategory, itemSubCategory, itemPrice, itemAvailable) };
                if (items[0] == null)
                    items = null;
            }
            else if (itemId == 0)
            {
                //items = itemManager.Readitems(itemName, itemPrice);
            }

            if (items != null)
            {
                // Reset also populates listboxitems with list items as data source
                ResetListBoxItemSearch();
            }
            else
            {
                lbItemSearch.DataSource = null;
                lbItemSearch.Items.Clear();
                lbItemSearch.Items.Add("There is no such Item.");
            }
        }

        private void DisableItemDetailsGroup()
        {
            gbItemDeatils.Enabled = false;
            ResetItemDetails();

            lbItemSearch.SelectedIndexChanged -= lbItemSearch_SelectedIndexChanged;
            lbItemSearch.DataSource = null;
            lbItemSearch.Items.Clear();
            lbItemSearch.SelectedIndexChanged += lbItemSearch_SelectedIndexChanged;
        }
        private void EnableItemDetailsGroup()
        {
            gbItemDeatils.Enabled = true;
            tbNameDetails.Text = selectedItem.Name;
            tbPriceDetails.Text = selectedItem.Price.ToString();
            cbAvailableDetails.Checked = selectedItem.Available;
            tbUnitTypeDetails.Text = selectedItem.UnitType;
        }

        private void btnItemCreate_Click(object sender, EventArgs e)
        {
            Item newItem = new Item();

            if (tbNameCreator.Text.Length >= 2 && tbNameCreator.Text.Length <= 20)
            {
                newItem.Name = tbNameCreator.Text;
            }
            else
            {
                MessageBox.Show("New Item Name should be between 2 and 20 characters");
                return;
            }

            newItem.Category = (ItemCategory)cbCategoryCreator.SelectedValue;
            newItem.SubCategory = (ItemCategory)cbSubCategoryCreator.SelectedValue;

            try
            {
                if (decimal.Parse(tbPriceCreator.Text) >= 0)
                {
                    newItem.Price = decimal.Parse(tbPriceCreator.Text);
                }
                else
                {
                    MessageBox.Show("New Admin data is not valid");
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Price is an positive Intiger");
                return;
            }

            if (cbAvailableCreator.Checked)
            {
                newItem.Available = true;
            }
            else
            {
                newItem.Available = false;
            }

            if (tbUnitTypeCreator.Text.Length >= 1 && tbUnitTypeCreator.Text.Length <= 20)
            {
                newItem.UnitType = tbUnitTypeCreator.Text;
            }
            else
            {
                MessageBox.Show("New Item UnitType should be between 1 and 20 characters");
                return;
            }

            bool created = itemManager.CreateItem(newItem);
            if (created)
            {
                MessageBox.Show("New item created succesfully");
            }
            else
            {
                MessageBox.Show("Couldn't create new item");
            }
            ResetItemCreator();
        }

        private void ResetItemSearch()
        {
            tbIdSearch.Text = String.Empty;
            tbNameSearch.Text = String.Empty;
            tbPriceSearch.Text = String.Empty;
            cbAvailableSearch.Checked = true;
        }

        private void ResetListBoxItemSearch()
        {
            lbItemSearch.SelectedIndexChanged -= lbItemSearch_SelectedIndexChanged;
            lbItemSearch.DataSource = null;
            lbItemSearch.DataSource = items;
            lbItemSearch.SelectedIndex = -1;
            lbItemSearch.SelectedIndexChanged += lbItemSearch_SelectedIndexChanged;
        }

        private void ResetItemDetails()
        {
            tbNameDetails.Text = String.Empty;
            tbPriceDetails.Text = String.Empty;
            cbAvailableDetails.Checked = true;
            tbUnitTypeDetails.Text = String.Empty;
        }

        private void ResetItemCreator()
        {
            tbNameCreator.Text = String.Empty;
            tbPriceCreator.Text = String.Empty;
            cbAvailableCreator.Checked = true;
            tbUnitTypeCreator.Text = String.Empty;
        }

        private void cbCategoryCreator_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSubCategoryCreator.DataSource = null;
            cbSubCategoryCreator.Items.Clear();
            cbSubCategoryCreator.DataSource = itemSubCategories.FindAll(x => x.ParentCategory == cbCategoryCreator.SelectedValue);
        }

        private void cbCategoryDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSubCategoryDetails.DataSource = null;
            cbSubCategoryDetails.Items.Clear();
            cbSubCategoryDetails.DataSource = itemSubCategories.FindAll(x => x.ParentCategory == cbCategoryDetails.SelectedValue);
        }

        private void cbCategorySearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSubCategorySearch.DataSource = null;
            cbSubCategorySearch.Items.Clear();
            cbSubCategorySearch.DataSource = itemSubCategories.FindAll(x => x.ParentCategory == cbCategorySearch.SelectedValue);
        }

        private void lbItemSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedItem = (Item)lbItemSearch.SelectedValue;
            EnableItemDetailsGroup();
        }
    }
}