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
        public Main()
        {
            itemRepository = new ItemRepository();
            itemManager = new ItemManager(itemRepository);
            InitializeComponent();
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

            newItem.Category = new ItemCategory(1, "Fruit");
            newItem.SubCategory = new ItemCategory(3, "Fruit", newItem.Category);

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

            if (tbUnitTypeCreator.Text.Length >= 2 && tbUnitTypeCreator.Text.Length <= 20)
            {
                newItem.UnitType = tbUnitTypeCreator.Text;
            }
            else
            {
                MessageBox.Show("New Item UnitType should be between 2 and 20 characters");
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
            tbCategoryCreator.Text = String.Empty;
            tbSubCategoryCreator.Text = String.Empty;
            tbPriceCreator.Text = String.Empty;
            cbAvailableCreator.Checked = true;
        }
    }
}