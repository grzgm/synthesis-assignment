namespace WinFormsApp
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tpItems = new System.Windows.Forms.TabPage();
			this.gbItemCreator = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.cbSubCategoryCreator = new System.Windows.Forms.ComboBox();
			this.tbStockAmountCreator = new System.Windows.Forms.TextBox();
			this.cbCategoryCreator = new System.Windows.Forms.ComboBox();
			this.cbAvailableCreator = new System.Windows.Forms.CheckBox();
			this.lbAvailableCreator = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.lbNameCreator = new System.Windows.Forms.Label();
			this.btnItemCreate = new System.Windows.Forms.Button();
			this.lbUnitTypeCreator = new System.Windows.Forms.Label();
			this.tbUnitTypeCreator = new System.Windows.Forms.TextBox();
			this.tbNameCreator = new System.Windows.Forms.TextBox();
			this.tbPriceCreator = new System.Windows.Forms.TextBox();
			this.gbItemDeatils = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cbAvailableDetails = new System.Windows.Forms.CheckBox();
			this.cbSubCategoryDetails = new System.Windows.Forms.ComboBox();
			this.lbAvailableDetails = new System.Windows.Forms.Label();
			this.cbCategoryDetails = new System.Windows.Forms.ComboBox();
			this.btnItemDelete = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.btnItemUpdate = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.lbStockAmountDetails = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tbStockAmountDetails = new System.Windows.Forms.TextBox();
			this.lbNameDetails = new System.Windows.Forms.Label();
			this.tbUnitTypeDetails = new System.Windows.Forms.TextBox();
			this.tbNameDetails = new System.Windows.Forms.TextBox();
			this.tbPriceDetails = new System.Windows.Forms.TextBox();
			this.gbItemSearch = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbIdSearch = new System.Windows.Forms.TextBox();
			this.cbAvailableSearch = new System.Windows.Forms.CheckBox();
			this.lbItemSearch = new System.Windows.Forms.ListBox();
			this.cbSubCategorySearch = new System.Windows.Forms.ComboBox();
			this.lbAvailableSearch = new System.Windows.Forms.Label();
			this.cbCategorySearch = new System.Windows.Forms.ComboBox();
			this.btnItemSearch = new System.Windows.Forms.Button();
			this.lbPriceSearch = new System.Windows.Forms.Label();
			this.tbPriceSearch = new System.Windows.Forms.TextBox();
			this.lbSubCategorySearch = new System.Windows.Forms.Label();
			this.lbCategorySearch = new System.Windows.Forms.Label();
			this.lbNameSearch = new System.Windows.Forms.Label();
			this.tbNameSearch = new System.Windows.Forms.TextBox();
			this.tpItemCategories = new System.Windows.Forms.TabPage();
			this.gbSubCategories = new System.Windows.Forms.GroupBox();
			this.gbCategories = new System.Windows.Forms.GroupBox();
			this.label12 = new System.Windows.Forms.Label();
			this.tbSubCategoryName = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.tbSubCategoryCategoryName = new System.Windows.Forms.TextBox();
			this.tbCategoryName = new System.Windows.Forms.TextBox();
			this.cbCategories = new System.Windows.Forms.ComboBox();
			this.btCategoryCreate = new System.Windows.Forms.Button();
			this.btSubCategoryCreate = new System.Windows.Forms.Button();
			this.tabControl.SuspendLayout();
			this.tpItems.SuspendLayout();
			this.gbItemCreator.SuspendLayout();
			this.gbItemDeatils.SuspendLayout();
			this.gbItemSearch.SuspendLayout();
			this.tpItemCategories.SuspendLayout();
			this.gbSubCategories.SuspendLayout();
			this.gbCategories.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tpItems);
			this.tabControl.Controls.Add(this.tpItemCategories);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Margin = new System.Windows.Forms.Padding(2);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(1518, 819);
			this.tabControl.TabIndex = 0;
			// 
			// tpItems
			// 
			this.tpItems.Controls.Add(this.gbItemCreator);
			this.tpItems.Controls.Add(this.gbItemDeatils);
			this.tpItems.Controls.Add(this.gbItemSearch);
			this.tpItems.Location = new System.Drawing.Point(4, 29);
			this.tpItems.Margin = new System.Windows.Forms.Padding(2);
			this.tpItems.Name = "tpItems";
			this.tpItems.Padding = new System.Windows.Forms.Padding(2);
			this.tpItems.Size = new System.Drawing.Size(1510, 786);
			this.tpItems.TabIndex = 0;
			this.tpItems.Text = "Items";
			this.tpItems.UseVisualStyleBackColor = true;
			// 
			// gbItemCreator
			// 
			this.gbItemCreator.Controls.Add(this.label9);
			this.gbItemCreator.Controls.Add(this.cbSubCategoryCreator);
			this.gbItemCreator.Controls.Add(this.tbStockAmountCreator);
			this.gbItemCreator.Controls.Add(this.cbCategoryCreator);
			this.gbItemCreator.Controls.Add(this.cbAvailableCreator);
			this.gbItemCreator.Controls.Add(this.lbAvailableCreator);
			this.gbItemCreator.Controls.Add(this.label6);
			this.gbItemCreator.Controls.Add(this.label7);
			this.gbItemCreator.Controls.Add(this.label8);
			this.gbItemCreator.Controls.Add(this.lbNameCreator);
			this.gbItemCreator.Controls.Add(this.btnItemCreate);
			this.gbItemCreator.Controls.Add(this.lbUnitTypeCreator);
			this.gbItemCreator.Controls.Add(this.tbUnitTypeCreator);
			this.gbItemCreator.Controls.Add(this.tbNameCreator);
			this.gbItemCreator.Controls.Add(this.tbPriceCreator);
			this.gbItemCreator.Dock = System.Windows.Forms.DockStyle.Right;
			this.gbItemCreator.Location = new System.Drawing.Point(1008, 2);
			this.gbItemCreator.Margin = new System.Windows.Forms.Padding(2);
			this.gbItemCreator.Name = "gbItemCreator";
			this.gbItemCreator.Padding = new System.Windows.Forms.Padding(2);
			this.gbItemCreator.Size = new System.Drawing.Size(500, 782);
			this.gbItemCreator.TabIndex = 2;
			this.gbItemCreator.TabStop = false;
			this.gbItemCreator.Text = "Item Creator";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(5, 203);
			this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(98, 20);
			this.label9.TabIndex = 51;
			this.label9.Text = "StockAmount";
			// 
			// cbSubCategoryCreator
			// 
			this.cbSubCategoryCreator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSubCategoryCreator.FormattingEnabled = true;
			this.cbSubCategoryCreator.Location = new System.Drawing.Point(211, 83);
			this.cbSubCategoryCreator.Margin = new System.Windows.Forms.Padding(2);
			this.cbSubCategoryCreator.Name = "cbSubCategoryCreator";
			this.cbSubCategoryCreator.Size = new System.Drawing.Size(271, 28);
			this.cbSubCategoryCreator.TabIndex = 47;
			// 
			// tbStockAmountCreator
			// 
			this.tbStockAmountCreator.Location = new System.Drawing.Point(211, 201);
			this.tbStockAmountCreator.Margin = new System.Windows.Forms.Padding(2);
			this.tbStockAmountCreator.Name = "tbStockAmountCreator";
			this.tbStockAmountCreator.Size = new System.Drawing.Size(271, 27);
			this.tbStockAmountCreator.TabIndex = 50;
			// 
			// cbCategoryCreator
			// 
			this.cbCategoryCreator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCategoryCreator.FormattingEnabled = true;
			this.cbCategoryCreator.Location = new System.Drawing.Point(211, 54);
			this.cbCategoryCreator.Margin = new System.Windows.Forms.Padding(2);
			this.cbCategoryCreator.Name = "cbCategoryCreator";
			this.cbCategoryCreator.Size = new System.Drawing.Size(271, 28);
			this.cbCategoryCreator.TabIndex = 16;
			this.cbCategoryCreator.SelectedIndexChanged += new System.EventHandler(this.cbCategoryCreator_SelectedIndexChanged);
			// 
			// cbAvailableCreator
			// 
			this.cbAvailableCreator.AutoSize = true;
			this.cbAvailableCreator.Checked = true;
			this.cbAvailableCreator.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbAvailableCreator.Location = new System.Drawing.Point(211, 142);
			this.cbAvailableCreator.Margin = new System.Windows.Forms.Padding(2);
			this.cbAvailableCreator.Name = "cbAvailableCreator";
			this.cbAvailableCreator.Size = new System.Drawing.Size(52, 24);
			this.cbAvailableCreator.TabIndex = 46;
			this.cbAvailableCreator.Text = "Yes";
			this.cbAvailableCreator.UseVisualStyleBackColor = true;
			// 
			// lbAvailableCreator
			// 
			this.lbAvailableCreator.AutoSize = true;
			this.lbAvailableCreator.Location = new System.Drawing.Point(5, 145);
			this.lbAvailableCreator.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbAvailableCreator.Name = "lbAvailableCreator";
			this.lbAvailableCreator.Size = new System.Drawing.Size(69, 20);
			this.lbAvailableCreator.TabIndex = 43;
			this.lbAvailableCreator.Text = "available";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(5, 115);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(42, 20);
			this.label6.TabIndex = 42;
			this.label6.Text = "price";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(5, 86);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(90, 20);
			this.label7.TabIndex = 41;
			this.label7.Text = "subcategory";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(5, 56);
			this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(67, 20);
			this.label8.TabIndex = 40;
			this.label8.Text = "category";
			// 
			// lbNameCreator
			// 
			this.lbNameCreator.AutoSize = true;
			this.lbNameCreator.Location = new System.Drawing.Point(5, 26);
			this.lbNameCreator.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbNameCreator.Name = "lbNameCreator";
			this.lbNameCreator.Size = new System.Drawing.Size(46, 20);
			this.lbNameCreator.TabIndex = 39;
			this.lbNameCreator.Text = "name";
			// 
			// btnItemCreate
			// 
			this.btnItemCreate.Location = new System.Drawing.Point(5, 231);
			this.btnItemCreate.Margin = new System.Windows.Forms.Padding(2);
			this.btnItemCreate.Name = "btnItemCreate";
			this.btnItemCreate.Size = new System.Drawing.Size(477, 27);
			this.btnItemCreate.TabIndex = 28;
			this.btnItemCreate.Text = "Create";
			this.btnItemCreate.UseVisualStyleBackColor = true;
			this.btnItemCreate.Click += new System.EventHandler(this.btnItemCreate_Click);
			// 
			// lbUnitTypeCreator
			// 
			this.lbUnitTypeCreator.AutoSize = true;
			this.lbUnitTypeCreator.Location = new System.Drawing.Point(5, 174);
			this.lbUnitTypeCreator.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbUnitTypeCreator.Name = "lbUnitTypeCreator";
			this.lbUnitTypeCreator.Size = new System.Drawing.Size(65, 20);
			this.lbUnitTypeCreator.TabIndex = 38;
			this.lbUnitTypeCreator.Text = "unitType";
			// 
			// tbUnitTypeCreator
			// 
			this.tbUnitTypeCreator.Location = new System.Drawing.Point(211, 172);
			this.tbUnitTypeCreator.Margin = new System.Windows.Forms.Padding(2);
			this.tbUnitTypeCreator.Name = "tbUnitTypeCreator";
			this.tbUnitTypeCreator.Size = new System.Drawing.Size(271, 27);
			this.tbUnitTypeCreator.TabIndex = 37;
			// 
			// tbNameCreator
			// 
			this.tbNameCreator.Location = new System.Drawing.Point(211, 24);
			this.tbNameCreator.Margin = new System.Windows.Forms.Padding(2);
			this.tbNameCreator.Name = "tbNameCreator";
			this.tbNameCreator.Size = new System.Drawing.Size(271, 27);
			this.tbNameCreator.TabIndex = 27;
			// 
			// tbPriceCreator
			// 
			this.tbPriceCreator.Location = new System.Drawing.Point(211, 113);
			this.tbPriceCreator.Margin = new System.Windows.Forms.Padding(2);
			this.tbPriceCreator.Name = "tbPriceCreator";
			this.tbPriceCreator.Size = new System.Drawing.Size(271, 27);
			this.tbPriceCreator.TabIndex = 33;
			// 
			// gbItemDeatils
			// 
			this.gbItemDeatils.Controls.Add(this.label5);
			this.gbItemDeatils.Controls.Add(this.cbAvailableDetails);
			this.gbItemDeatils.Controls.Add(this.cbSubCategoryDetails);
			this.gbItemDeatils.Controls.Add(this.lbAvailableDetails);
			this.gbItemDeatils.Controls.Add(this.cbCategoryDetails);
			this.gbItemDeatils.Controls.Add(this.btnItemDelete);
			this.gbItemDeatils.Controls.Add(this.label2);
			this.gbItemDeatils.Controls.Add(this.btnItemUpdate);
			this.gbItemDeatils.Controls.Add(this.label3);
			this.gbItemDeatils.Controls.Add(this.lbStockAmountDetails);
			this.gbItemDeatils.Controls.Add(this.label4);
			this.gbItemDeatils.Controls.Add(this.tbStockAmountDetails);
			this.gbItemDeatils.Controls.Add(this.lbNameDetails);
			this.gbItemDeatils.Controls.Add(this.tbUnitTypeDetails);
			this.gbItemDeatils.Controls.Add(this.tbNameDetails);
			this.gbItemDeatils.Controls.Add(this.tbPriceDetails);
			this.gbItemDeatils.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbItemDeatils.Location = new System.Drawing.Point(494, 2);
			this.gbItemDeatils.Margin = new System.Windows.Forms.Padding(2);
			this.gbItemDeatils.Name = "gbItemDeatils";
			this.gbItemDeatils.Padding = new System.Windows.Forms.Padding(2);
			this.gbItemDeatils.Size = new System.Drawing.Size(1014, 782);
			this.gbItemDeatils.TabIndex = 1;
			this.gbItemDeatils.TabStop = false;
			this.gbItemDeatils.Text = "Item Details";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(34, 174);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(65, 20);
			this.label5.TabIndex = 48;
			this.label5.Text = "unitType";
			// 
			// cbAvailableDetails
			// 
			this.cbAvailableDetails.AutoSize = true;
			this.cbAvailableDetails.Checked = true;
			this.cbAvailableDetails.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbAvailableDetails.Location = new System.Drawing.Point(240, 142);
			this.cbAvailableDetails.Margin = new System.Windows.Forms.Padding(2);
			this.cbAvailableDetails.Name = "cbAvailableDetails";
			this.cbAvailableDetails.Size = new System.Drawing.Size(52, 24);
			this.cbAvailableDetails.TabIndex = 48;
			this.cbAvailableDetails.Text = "Yes";
			this.cbAvailableDetails.UseVisualStyleBackColor = true;
			// 
			// cbSubCategoryDetails
			// 
			this.cbSubCategoryDetails.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSubCategoryDetails.FormattingEnabled = true;
			this.cbSubCategoryDetails.Location = new System.Drawing.Point(240, 83);
			this.cbSubCategoryDetails.Margin = new System.Windows.Forms.Padding(2);
			this.cbSubCategoryDetails.Name = "cbSubCategoryDetails";
			this.cbSubCategoryDetails.Size = new System.Drawing.Size(271, 28);
			this.cbSubCategoryDetails.TabIndex = 49;
			// 
			// lbAvailableDetails
			// 
			this.lbAvailableDetails.AutoSize = true;
			this.lbAvailableDetails.Location = new System.Drawing.Point(34, 145);
			this.lbAvailableDetails.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbAvailableDetails.Name = "lbAvailableDetails";
			this.lbAvailableDetails.Size = new System.Drawing.Size(69, 20);
			this.lbAvailableDetails.TabIndex = 20;
			this.lbAvailableDetails.Text = "available";
			// 
			// cbCategoryDetails
			// 
			this.cbCategoryDetails.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCategoryDetails.FormattingEnabled = true;
			this.cbCategoryDetails.Location = new System.Drawing.Point(240, 54);
			this.cbCategoryDetails.Margin = new System.Windows.Forms.Padding(2);
			this.cbCategoryDetails.Name = "cbCategoryDetails";
			this.cbCategoryDetails.Size = new System.Drawing.Size(271, 28);
			this.cbCategoryDetails.TabIndex = 48;
			this.cbCategoryDetails.SelectedIndexChanged += new System.EventHandler(this.cbCategoryDetails_SelectedIndexChanged);
			// 
			// btnItemDelete
			// 
			this.btnItemDelete.Location = new System.Drawing.Point(34, 263);
			this.btnItemDelete.Margin = new System.Windows.Forms.Padding(2);
			this.btnItemDelete.Name = "btnItemDelete";
			this.btnItemDelete.Size = new System.Drawing.Size(477, 27);
			this.btnItemDelete.TabIndex = 27;
			this.btnItemDelete.Text = "Delete";
			this.btnItemDelete.UseVisualStyleBackColor = true;
			this.btnItemDelete.Click += new System.EventHandler(this.btnItemDelete_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(34, 115);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 20);
			this.label2.TabIndex = 19;
			this.label2.Text = "price";
			// 
			// btnItemUpdate
			// 
			this.btnItemUpdate.Location = new System.Drawing.Point(34, 231);
			this.btnItemUpdate.Margin = new System.Windows.Forms.Padding(2);
			this.btnItemUpdate.Name = "btnItemUpdate";
			this.btnItemUpdate.Size = new System.Drawing.Size(477, 27);
			this.btnItemUpdate.TabIndex = 14;
			this.btnItemUpdate.Text = "Update";
			this.btnItemUpdate.UseVisualStyleBackColor = true;
			this.btnItemUpdate.Click += new System.EventHandler(this.btnItemUpdate_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(34, 86);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(90, 20);
			this.label3.TabIndex = 18;
			this.label3.Text = "subcategory";
			// 
			// lbStockAmountDetails
			// 
			this.lbStockAmountDetails.AutoSize = true;
			this.lbStockAmountDetails.Location = new System.Drawing.Point(34, 204);
			this.lbStockAmountDetails.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbStockAmountDetails.Name = "lbStockAmountDetails";
			this.lbStockAmountDetails.Size = new System.Drawing.Size(98, 20);
			this.lbStockAmountDetails.TabIndex = 26;
			this.lbStockAmountDetails.Text = "StockAmount";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(34, 56);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(67, 20);
			this.label4.TabIndex = 17;
			this.label4.Text = "category";
			// 
			// tbStockAmountDetails
			// 
			this.tbStockAmountDetails.Location = new System.Drawing.Point(240, 202);
			this.tbStockAmountDetails.Margin = new System.Windows.Forms.Padding(2);
			this.tbStockAmountDetails.Name = "tbStockAmountDetails";
			this.tbStockAmountDetails.Size = new System.Drawing.Size(271, 27);
			this.tbStockAmountDetails.TabIndex = 25;
			// 
			// lbNameDetails
			// 
			this.lbNameDetails.AutoSize = true;
			this.lbNameDetails.Location = new System.Drawing.Point(34, 26);
			this.lbNameDetails.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbNameDetails.Name = "lbNameDetails";
			this.lbNameDetails.Size = new System.Drawing.Size(46, 20);
			this.lbNameDetails.TabIndex = 16;
			this.lbNameDetails.Text = "name";
			// 
			// tbUnitTypeDetails
			// 
			this.tbUnitTypeDetails.Location = new System.Drawing.Point(240, 172);
			this.tbUnitTypeDetails.Margin = new System.Windows.Forms.Padding(2);
			this.tbUnitTypeDetails.Name = "tbUnitTypeDetails";
			this.tbUnitTypeDetails.Size = new System.Drawing.Size(271, 27);
			this.tbUnitTypeDetails.TabIndex = 23;
			// 
			// tbNameDetails
			// 
			this.tbNameDetails.Location = new System.Drawing.Point(240, 24);
			this.tbNameDetails.Margin = new System.Windows.Forms.Padding(2);
			this.tbNameDetails.Name = "tbNameDetails";
			this.tbNameDetails.Size = new System.Drawing.Size(271, 27);
			this.tbNameDetails.TabIndex = 13;
			// 
			// tbPriceDetails
			// 
			this.tbPriceDetails.Location = new System.Drawing.Point(240, 113);
			this.tbPriceDetails.Margin = new System.Windows.Forms.Padding(2);
			this.tbPriceDetails.Name = "tbPriceDetails";
			this.tbPriceDetails.Size = new System.Drawing.Size(271, 27);
			this.tbPriceDetails.TabIndex = 19;
			// 
			// gbItemSearch
			// 
			this.gbItemSearch.Controls.Add(this.label1);
			this.gbItemSearch.Controls.Add(this.tbIdSearch);
			this.gbItemSearch.Controls.Add(this.cbAvailableSearch);
			this.gbItemSearch.Controls.Add(this.lbItemSearch);
			this.gbItemSearch.Controls.Add(this.cbSubCategorySearch);
			this.gbItemSearch.Controls.Add(this.lbAvailableSearch);
			this.gbItemSearch.Controls.Add(this.cbCategorySearch);
			this.gbItemSearch.Controls.Add(this.btnItemSearch);
			this.gbItemSearch.Controls.Add(this.lbPriceSearch);
			this.gbItemSearch.Controls.Add(this.tbPriceSearch);
			this.gbItemSearch.Controls.Add(this.lbSubCategorySearch);
			this.gbItemSearch.Controls.Add(this.lbCategorySearch);
			this.gbItemSearch.Controls.Add(this.lbNameSearch);
			this.gbItemSearch.Controls.Add(this.tbNameSearch);
			this.gbItemSearch.Dock = System.Windows.Forms.DockStyle.Left;
			this.gbItemSearch.Location = new System.Drawing.Point(2, 2);
			this.gbItemSearch.Margin = new System.Windows.Forms.Padding(2);
			this.gbItemSearch.Name = "gbItemSearch";
			this.gbItemSearch.Padding = new System.Windows.Forms.Padding(2);
			this.gbItemSearch.Size = new System.Drawing.Size(492, 782);
			this.gbItemSearch.TabIndex = 0;
			this.gbItemSearch.TabStop = false;
			this.gbItemSearch.Text = "Item Search";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 26);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(22, 20);
			this.label1.TabIndex = 54;
			this.label1.Text = "id";
			// 
			// tbIdSearch
			// 
			this.tbIdSearch.Location = new System.Drawing.Point(217, 24);
			this.tbIdSearch.Margin = new System.Windows.Forms.Padding(2);
			this.tbIdSearch.Name = "tbIdSearch";
			this.tbIdSearch.Size = new System.Drawing.Size(271, 27);
			this.tbIdSearch.TabIndex = 53;
			// 
			// cbAvailableSearch
			// 
			this.cbAvailableSearch.AutoSize = true;
			this.cbAvailableSearch.Checked = true;
			this.cbAvailableSearch.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbAvailableSearch.Location = new System.Drawing.Point(217, 172);
			this.cbAvailableSearch.Margin = new System.Windows.Forms.Padding(2);
			this.cbAvailableSearch.Name = "cbAvailableSearch";
			this.cbAvailableSearch.Size = new System.Drawing.Size(52, 24);
			this.cbAvailableSearch.TabIndex = 50;
			this.cbAvailableSearch.Text = "Yes";
			this.cbAvailableSearch.UseVisualStyleBackColor = true;
			// 
			// lbItemSearch
			// 
			this.lbItemSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lbItemSearch.FormattingEnabled = true;
			this.lbItemSearch.ItemHeight = 20;
			this.lbItemSearch.Location = new System.Drawing.Point(2, 236);
			this.lbItemSearch.Margin = new System.Windows.Forms.Padding(2);
			this.lbItemSearch.Name = "lbItemSearch";
			this.lbItemSearch.Size = new System.Drawing.Size(488, 544);
			this.lbItemSearch.TabIndex = 52;
			this.lbItemSearch.SelectedIndexChanged += new System.EventHandler(this.lbItemSearch_SelectedIndexChanged);
			// 
			// cbSubCategorySearch
			// 
			this.cbSubCategorySearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSubCategorySearch.FormattingEnabled = true;
			this.cbSubCategorySearch.Location = new System.Drawing.Point(217, 113);
			this.cbSubCategorySearch.Margin = new System.Windows.Forms.Padding(2);
			this.cbSubCategorySearch.Name = "cbSubCategorySearch";
			this.cbSubCategorySearch.Size = new System.Drawing.Size(271, 28);
			this.cbSubCategorySearch.TabIndex = 51;
			// 
			// lbAvailableSearch
			// 
			this.lbAvailableSearch.AutoSize = true;
			this.lbAvailableSearch.Location = new System.Drawing.Point(10, 174);
			this.lbAvailableSearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbAvailableSearch.Name = "lbAvailableSearch";
			this.lbAvailableSearch.Size = new System.Drawing.Size(69, 20);
			this.lbAvailableSearch.TabIndex = 15;
			this.lbAvailableSearch.Text = "available";
			// 
			// cbCategorySearch
			// 
			this.cbCategorySearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCategorySearch.FormattingEnabled = true;
			this.cbCategorySearch.Location = new System.Drawing.Point(217, 83);
			this.cbCategorySearch.Margin = new System.Windows.Forms.Padding(2);
			this.cbCategorySearch.Name = "cbCategorySearch";
			this.cbCategorySearch.Size = new System.Drawing.Size(271, 28);
			this.cbCategorySearch.TabIndex = 50;
			this.cbCategorySearch.SelectedIndexChanged += new System.EventHandler(this.cbCategorySearch_SelectedIndexChanged);
			// 
			// btnItemSearch
			// 
			this.btnItemSearch.Location = new System.Drawing.Point(10, 202);
			this.btnItemSearch.Margin = new System.Windows.Forms.Padding(2);
			this.btnItemSearch.Name = "btnItemSearch";
			this.btnItemSearch.Size = new System.Drawing.Size(477, 27);
			this.btnItemSearch.TabIndex = 13;
			this.btnItemSearch.Text = "Search";
			this.btnItemSearch.UseVisualStyleBackColor = true;
			this.btnItemSearch.Click += new System.EventHandler(this.btnItemSearch_Click);
			// 
			// lbPriceSearch
			// 
			this.lbPriceSearch.AutoSize = true;
			this.lbPriceSearch.Location = new System.Drawing.Point(10, 145);
			this.lbPriceSearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbPriceSearch.Name = "lbPriceSearch";
			this.lbPriceSearch.Size = new System.Drawing.Size(42, 20);
			this.lbPriceSearch.TabIndex = 11;
			this.lbPriceSearch.Text = "price";
			// 
			// tbPriceSearch
			// 
			this.tbPriceSearch.Location = new System.Drawing.Point(217, 142);
			this.tbPriceSearch.Margin = new System.Windows.Forms.Padding(2);
			this.tbPriceSearch.Name = "tbPriceSearch";
			this.tbPriceSearch.Size = new System.Drawing.Size(271, 27);
			this.tbPriceSearch.TabIndex = 10;
			// 
			// lbSubCategorySearch
			// 
			this.lbSubCategorySearch.AutoSize = true;
			this.lbSubCategorySearch.Location = new System.Drawing.Point(10, 115);
			this.lbSubCategorySearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbSubCategorySearch.Name = "lbSubCategorySearch";
			this.lbSubCategorySearch.Size = new System.Drawing.Size(90, 20);
			this.lbSubCategorySearch.TabIndex = 9;
			this.lbSubCategorySearch.Text = "subcategory";
			// 
			// lbCategorySearch
			// 
			this.lbCategorySearch.AutoSize = true;
			this.lbCategorySearch.Location = new System.Drawing.Point(10, 86);
			this.lbCategorySearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbCategorySearch.Name = "lbCategorySearch";
			this.lbCategorySearch.Size = new System.Drawing.Size(67, 20);
			this.lbCategorySearch.TabIndex = 7;
			this.lbCategorySearch.Text = "category";
			// 
			// lbNameSearch
			// 
			this.lbNameSearch.AutoSize = true;
			this.lbNameSearch.Location = new System.Drawing.Point(10, 56);
			this.lbNameSearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbNameSearch.Name = "lbNameSearch";
			this.lbNameSearch.Size = new System.Drawing.Size(46, 20);
			this.lbNameSearch.TabIndex = 5;
			this.lbNameSearch.Text = "name";
			// 
			// tbNameSearch
			// 
			this.tbNameSearch.Location = new System.Drawing.Point(217, 54);
			this.tbNameSearch.Margin = new System.Windows.Forms.Padding(2);
			this.tbNameSearch.Name = "tbNameSearch";
			this.tbNameSearch.Size = new System.Drawing.Size(271, 27);
			this.tbNameSearch.TabIndex = 0;
			// 
			// tpItemCategories
			// 
			this.tpItemCategories.Controls.Add(this.gbSubCategories);
			this.tpItemCategories.Controls.Add(this.gbCategories);
			this.tpItemCategories.Location = new System.Drawing.Point(4, 29);
			this.tpItemCategories.Margin = new System.Windows.Forms.Padding(2);
			this.tpItemCategories.Name = "tpItemCategories";
			this.tpItemCategories.Padding = new System.Windows.Forms.Padding(2);
			this.tpItemCategories.Size = new System.Drawing.Size(1510, 786);
			this.tpItemCategories.TabIndex = 1;
			this.tpItemCategories.Text = "Item Categories";
			this.tpItemCategories.UseVisualStyleBackColor = true;
			// 
			// gbSubCategories
			// 
			this.gbSubCategories.Controls.Add(this.btSubCategoryCreate);
			this.gbSubCategories.Controls.Add(this.cbCategories);
			this.gbSubCategories.Controls.Add(this.label12);
			this.gbSubCategories.Controls.Add(this.tbSubCategoryName);
			this.gbSubCategories.Location = new System.Drawing.Point(358, 8);
			this.gbSubCategories.Name = "gbSubCategories";
			this.gbSubCategories.Size = new System.Drawing.Size(371, 308);
			this.gbSubCategories.TabIndex = 1;
			this.gbSubCategories.TabStop = false;
			this.gbSubCategories.Text = "SubCategories";
			// 
			// gbCategories
			// 
			this.gbCategories.Controls.Add(this.btCategoryCreate);
			this.gbCategories.Controls.Add(this.label11);
			this.gbCategories.Controls.Add(this.label10);
			this.gbCategories.Controls.Add(this.tbSubCategoryCategoryName);
			this.gbCategories.Controls.Add(this.tbCategoryName);
			this.gbCategories.Location = new System.Drawing.Point(8, 8);
			this.gbCategories.Name = "gbCategories";
			this.gbCategories.Size = new System.Drawing.Size(344, 308);
			this.gbCategories.TabIndex = 0;
			this.gbCategories.TabStop = false;
			this.gbCategories.Text = "Categories";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(17, 59);
			this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(135, 20);
			this.label12.TabIndex = 11;
			this.label12.Text = "SubCategory name";
			// 
			// tbSubCategoryName
			// 
			this.tbSubCategoryName.Location = new System.Drawing.Point(161, 56);
			this.tbSubCategoryName.Margin = new System.Windows.Forms.Padding(2);
			this.tbSubCategoryName.Name = "tbSubCategoryName";
			this.tbSubCategoryName.Size = new System.Drawing.Size(190, 27);
			this.tbSubCategoryName.TabIndex = 10;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(5, 59);
			this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(135, 20);
			this.label11.TabIndex = 9;
			this.label11.Text = "SubCategory name";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(5, 28);
			this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(110, 20);
			this.label10.TabIndex = 7;
			this.label10.Text = "Category name";
			// 
			// tbSubCategoryCategoryName
			// 
			this.tbSubCategoryCategoryName.Location = new System.Drawing.Point(149, 56);
			this.tbSubCategoryCategoryName.Margin = new System.Windows.Forms.Padding(2);
			this.tbSubCategoryCategoryName.Name = "tbSubCategoryCategoryName";
			this.tbSubCategoryCategoryName.Size = new System.Drawing.Size(190, 27);
			this.tbSubCategoryCategoryName.TabIndex = 8;
			// 
			// tbCategoryName
			// 
			this.tbCategoryName.Location = new System.Drawing.Point(149, 25);
			this.tbCategoryName.Margin = new System.Windows.Forms.Padding(2);
			this.tbCategoryName.Name = "tbCategoryName";
			this.tbCategoryName.Size = new System.Drawing.Size(190, 27);
			this.tbCategoryName.TabIndex = 6;
			// 
			// cbCategories
			// 
			this.cbCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCategories.FormattingEnabled = true;
			this.cbCategories.Location = new System.Drawing.Point(17, 24);
			this.cbCategories.Margin = new System.Windows.Forms.Padding(2);
			this.cbCategories.Name = "cbCategories";
			this.cbCategories.Size = new System.Drawing.Size(334, 28);
			this.cbCategories.TabIndex = 51;
			// 
			// btCategoryCreate
			// 
			this.btCategoryCreate.Location = new System.Drawing.Point(5, 88);
			this.btCategoryCreate.Name = "btCategoryCreate";
			this.btCategoryCreate.Size = new System.Drawing.Size(333, 29);
			this.btCategoryCreate.TabIndex = 2;
			this.btCategoryCreate.Text = "Add";
			this.btCategoryCreate.UseVisualStyleBackColor = true;
			// 
			// btSubCategoryCreate
			// 
			this.btSubCategoryCreate.Location = new System.Drawing.Point(18, 88);
			this.btSubCategoryCreate.Name = "btSubCategoryCreate";
			this.btSubCategoryCreate.Size = new System.Drawing.Size(333, 29);
			this.btSubCategoryCreate.TabIndex = 10;
			this.btSubCategoryCreate.Text = "Add";
			this.btSubCategoryCreate.UseVisualStyleBackColor = true;
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1518, 819);
			this.Controls.Add(this.tabControl);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "Main";
			this.Text = "RobertHeijn B.V.";
			this.tabControl.ResumeLayout(false);
			this.tpItems.ResumeLayout(false);
			this.gbItemCreator.ResumeLayout(false);
			this.gbItemCreator.PerformLayout();
			this.gbItemDeatils.ResumeLayout(false);
			this.gbItemDeatils.PerformLayout();
			this.gbItemSearch.ResumeLayout(false);
			this.gbItemSearch.PerformLayout();
			this.tpItemCategories.ResumeLayout(false);
			this.gbSubCategories.ResumeLayout(false);
			this.gbSubCategories.PerformLayout();
			this.gbCategories.ResumeLayout(false);
			this.gbCategories.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl;
        private TabPage tpItems;
        private TabPage tpItemCategories;
        private GroupBox gbItemCreator;
        private GroupBox gbItemDeatils;
        private GroupBox gbItemSearch;
        private Label lbNameSearch;
        private TextBox tbNameSearch;
        private Label lbStockAmountDetails;
        private TextBox tbStockAmountDetails;
        private TextBox tbUnitTypeDetails;
        private TextBox tbNameDetails;
        private TextBox tbPriceDetails;
        private Label lbPriceSearch;
        private TextBox tbPriceSearch;
        private Label lbSubCategorySearch;
        private Label lbCategorySearch;
        private Button btnItemCreate;
        private Label lbUnitTypeCreator;
        private TextBox tbUnitTypeCreator;
        private TextBox tbNameCreator;
        private TextBox tbPriceCreator;
        private Button btnItemDelete;
        private Button btnItemUpdate;
        private Button btnItemSearch;
        private Label lbAvailableSearch;
        private Label lbAvailableCreator;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label lbNameCreator;
        private Label lbAvailableDetails;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lbNameDetails;
        private CheckBox cbAvailableCreator;
        private ComboBox cbSubCategoryCreator;
        private ComboBox cbCategoryCreator;
        private ComboBox cbSubCategoryDetails;
        private ComboBox cbCategoryDetails;
        private ComboBox cbSubCategorySearch;
        private ComboBox cbCategorySearch;
        private ListBox lbItemSearch;
        private CheckBox cbAvailableDetails;
        private Label label1;
        private TextBox tbIdSearch;
        private CheckBox cbAvailableSearch;
        private Label label5;
        private Label label9;
        private TextBox tbStockAmountCreator;
		private GroupBox gbSubCategories;
		private GroupBox gbCategories;
		private Label label10;
		private TextBox tbCategoryName;
		private Label label11;
		private TextBox tbSubCategoryCategoryName;
		private Label label12;
		private TextBox tbSubCategoryName;
		private ComboBox cbCategories;
		private Button btSubCategoryCreate;
		private Button btCategoryCreate;
	}
}