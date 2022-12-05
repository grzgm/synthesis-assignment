using DataAccessLayer;
using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Managers;
using LogicLayer.Models;
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
        public Main()
        {
            itemRepository = new ItemRepository();
            itemManager = new ItemManager(itemRepository);
            itemCategoryRepository = new ItemCategoryRepository();
            itemCategoryManager = new ItemCategoryManager(itemCategoryRepository);

            (itemCategories, itemSubCategories) = itemCategoryManager.ReadAllItemCategories();

            InitializeComponent();

            cbCategoryCreator.DataSource = new List<ItemCategory>(itemCategories);
            cbCategoryDetails.DataSource = new List<ItemCategory>(itemCategories);
            cbCategorySearch.DataSource = new List<ItemCategory>(itemCategories);


            lbItemSearch.DataSource = itemManager.ReadItems();
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
    }
}