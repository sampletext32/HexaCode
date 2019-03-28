using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Exception = System.Exception;

namespace HexaCode
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private int _selectedPartIndex = -1;
        private int _selectedCountryIndex = -1;
        private int _selectedManufacturerIndex = -1;

        private bool _editingPart = false;
        private bool _editingCountry = false;
        private bool _editingManufacturer = false;

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            LocalDataHolder.RefreshLocalData();
            FillData();
        }

        private void FillData()
        {
            listBoxParts.Items.Clear();
            listBoxCountries.Items.Clear();
            listBoxManufacturers.Items.Clear();

            LocalDataHolder.Part_SelectAll()
                .ForEach(part => listBoxParts.Items.Add($"{part.Id}: {part.Name}"));
            LocalDataHolder.Country_SelectAll()
                .ForEach(country => listBoxCountries.Items.Add($"{country.Id}: {country.Name}"));
            LocalDataHolder.Manufacturers_SelectAll().ForEach(manufacturer =>
                listBoxManufacturers.Items.Add($"{manufacturer.Id}: {manufacturer.Name}"));

            comboBoxPartCountry.Items.Clear();
            comboBoxPartManufacturer.Items.Clear();

            var countries = LocalDataHolder.Country_SelectAll();
            countries.ForEach(country =>
                comboBoxPartCountry.Items.Add($"{country.Id}: {country.Name}"));

            var manufacturers = LocalDataHolder.Manufacturers_SelectAll();
            manufacturers.ForEach(manufacturer =>
                comboBoxPartManufacturer.Items.Add($"{manufacturer.Id}: {manufacturer.Name}"));
        }

        private void listBoxParts_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedPartIndex = listBoxParts.SelectedIndex;
        }

        private void listBoxCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedCountryIndex = listBoxCountries.SelectedIndex;
        }

        private void listBoxManufacturers_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedManufacturerIndex = listBoxManufacturers.SelectedIndex;
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_editingPart && tabControlMain.SelectedIndex != 0)
            {
                tabControlMain.SelectedIndex = 0;
            }
            else if (_editingCountry && tabControlMain.SelectedIndex != 1)
            {
                tabControlMain.SelectedIndex = 1;
            }
            else if (_editingManufacturer && tabControlMain.SelectedIndex != 2)
            {
                tabControlMain.SelectedIndex = 2;
            }
        }

        private void ClearPartFields()
        {
            textBoxPartId.Text = string.Empty;

            comboBoxPartCountry.SelectedIndex = -1;

            comboBoxPartManufacturer.SelectedIndex = -1;

            textBoxPartName.Text = string.Empty;

            richTextBoxPartTechnicalData.Text = string.Empty;

            textBoxPartLifetime.Text = string.Empty;

            textBoxPartCount.Text = string.Empty;
        }

        private void ClearCountryFields()
        {
            textBoxCountryId.Text = string.Empty;
            textBoxCountryName.Text = string.Empty;
        }

        private void ClearManufacturerFields()
        {
            textBoxManufacturerId.Text = string.Empty;
            textBoxManufacturerName.Text = string.Empty;
        }

        private void buttonUpdatePart_Click(object sender, EventArgs e)
        {
            if (!_editingPart)
            {
                if (_selectedPartIndex == -1)
                {
                    MessageBox.Show("Select Part");
                    return;
                }

                try
                {
                    var part = LocalDataHolder.Part_Get(_selectedPartIndex);

                    textBoxPartId.Text = part.Id.ToString();

                    var countries = LocalDataHolder.Country_SelectAll();
                    var countryIndex = countries.FindIndex(t => t.Id == part.CountryId);
                    comboBoxPartCountry.SelectedIndex = countryIndex;

                    var manufacturers = LocalDataHolder.Manufacturers_SelectAll();
                    var manufacturerIndex = manufacturers.FindIndex(t => t.Id == part.ManufacturerId);
                    comboBoxPartManufacturer.SelectedIndex = manufacturerIndex;

                    textBoxPartName.Text = part.Name;

                    richTextBoxPartTechnicalData.Text = JToken.Parse(part.TechnicalData).ToString(Formatting.Indented);

                    textBoxPartLifetime.Text = part.Lifetime.ToString();

                    textBoxPartCount.Text = part.Count.ToString();
                }
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show("No Local Part With Index " + _selectedPartIndex + " Known");
                }

                buttonUpdatePart.Text = "Save";
                buttonInsertPart.Enabled = false;
                buttonCancelEditingPart.Enabled = true;
                _editingPart = true;
            }
            else
            {
                var id = int.Parse(textBoxPartId.Text);

                var countryId = LocalDataHolder.Country_Get(comboBoxPartCountry.SelectedIndex).Id;

                var manufacturerId = LocalDataHolder.Manufacturer_Get(comboBoxPartManufacturer.SelectedIndex).Id;

                var name = textBoxPartName.Text;

                string technicalData = "";

                try
                {
                    var technicalDataJson = JToken.Parse(richTextBoxPartTechnicalData.Text);
                    technicalData = technicalDataJson.ToString(Formatting.None);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error Parsing Technical Data JSON");
                    return;
                }

                var lifetime = int.Parse(textBoxPartLifetime.Text);

                var count = int.Parse(textBoxPartCount.Text);

                var part = new Part(id, countryId, manufacturerId, name, technicalData, lifetime, count);

                LocalDataHolder.Part_Update(part);

                ClearPartFields();

                FillData();

                buttonUpdatePart.Text = "Update";
                buttonInsertPart.Enabled = true;
                buttonCancelEditingPart.Enabled = false;
                _editingPart = false;
            }
        }

        private void buttonInsertPart_Click(object sender, EventArgs e)
        {
            if (!_editingPart)
            {
                textBoxPartId.Text = "0";

                buttonUpdatePart.Enabled = false;
                buttonInsertPart.Text = "Save";
                buttonCancelEditingPart.Enabled = true;
                _editingPart = true;
            }
            else
            {
                var id = int.Parse(textBoxPartId.Text);

                var countryId = LocalDataHolder.Country_Get(comboBoxPartCountry.SelectedIndex).Id;

                var manufacturerId = LocalDataHolder.Manufacturer_Get(comboBoxPartManufacturer.SelectedIndex).Id;

                var name = textBoxPartName.Text;

                string technicalData = "";

                try
                {
                    var technicalDataJson = JToken.Parse(richTextBoxPartTechnicalData.Text);
                    technicalData = technicalDataJson.ToString(Formatting.None);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error Parsing Technical Data JSON");
                    return;
                }


                var lifetime = int.Parse(textBoxPartLifetime.Text);

                var count = int.Parse(textBoxPartCount.Text);

                var part = new Part(id, countryId, manufacturerId, name, technicalData, lifetime, count);

                LocalDataHolder.Part_Insert(part);

                ClearPartFields();

                FillData();

                buttonUpdatePart.Enabled = true;
                buttonInsertPart.Text = "Insert";
                buttonCancelEditingPart.Enabled = false;

                _editingPart = false;
            }
        }

        private void buttonCancelEditingPart_Click(object sender, EventArgs e)
        {
            if (_editingPart)
            {
                ClearPartFields();

                buttonUpdatePart.Enabled = true;
                buttonUpdatePart.Text = "Update";
                buttonInsertPart.Enabled = true;
                buttonInsertPart.Text = "Insert";
                buttonCancelEditingPart.Enabled = false;

                _editingPart = false;
            }
        }

        private void buttonUpdateCountry_Click(object sender, EventArgs e)
        {
            if (!_editingCountry)
            {
                if (_selectedCountryIndex == -1)
                {
                    MessageBox.Show("Select Country");
                    return;
                }

                try
                {
                    var country = LocalDataHolder.Country_Get(_selectedCountryIndex);

                    textBoxCountryId.Text = country.Id.ToString();

                    textBoxCountryName.Text = country.Name;
                }
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show("No Local Country With Index " + _selectedCountryIndex + " Known");
                }

                buttonUpdateCountry.Text = "Save";
                buttonInsertCountry.Enabled = false;
                buttonCancelEditingCountry.Enabled = true;
                _editingCountry = true;
            }
            else
            {
                var id = int.Parse(textBoxCountryId.Text);

                var name = textBoxCountryName.Text;

                var country = new Country(id, name);

                LocalDataHolder.Country_Update(country);

                ClearCountryFields();

                FillData();

                buttonUpdateCountry.Text = "Update";
                buttonInsertCountry.Enabled = true;
                buttonCancelEditingCountry.Enabled = false;
                _editingCountry = false;
            }
        }

        private void buttonInsertCountry_Click(object sender, EventArgs e)
        {
            if (!_editingCountry)
            {
                textBoxCountryId.Text = "0";

                buttonUpdateCountry.Enabled = false;
                buttonInsertCountry.Text = "Save";
                buttonCancelEditingCountry.Enabled = true;
                _editingCountry = true;
            }
            else
            {
                var id = int.Parse(textBoxCountryId.Text);

                var name = textBoxCountryName.Text;

                var country = new Country(id, name);

                LocalDataHolder.Country_Insert(country);

                ClearPartFields();

                FillData();

                buttonUpdateCountry.Enabled = true;
                buttonInsertCountry.Text = "Insert";
                buttonCancelEditingCountry.Enabled = false;

                _editingCountry = false;
            }
        }

        private void buttonCancelEditingCountry_Click(object sender, EventArgs e)
        {
            if (_editingCountry)
            {
                ClearCountryFields();

                buttonUpdateCountry.Enabled = true;
                buttonUpdateCountry.Text = "Update";
                buttonInsertCountry.Enabled = true;
                buttonInsertCountry.Text = "Insert";
                buttonCancelEditingCountry.Enabled = false;

                _editingCountry = false;
            }
        }

        private void buttonUpdateManufacturer_Click(object sender, EventArgs e)
        {
            if (!_editingManufacturer)
            {
                if (_selectedManufacturerIndex == -1)
                {
                    MessageBox.Show("Select Manufacturer");
                    return;
                }

                try
                {
                    var manufacturer = LocalDataHolder.Manufacturer_Get(_selectedManufacturerIndex);

                    textBoxManufacturerId.Text = manufacturer.Id.ToString();

                    textBoxManufacturerName.Text = manufacturer.Name;
                }
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show("No Local Manufacturer With Index " + _selectedManufacturerIndex + " Known");
                }

                buttonUpdateManufacturer.Text = "Save";
                buttonInsertManufacturer.Enabled = false;
                buttonCancelEditingManufacturer.Enabled = true;
                _editingManufacturer = true;
            }
            else
            {
                var id = int.Parse(textBoxManufacturerId.Text);

                var name = textBoxManufacturerName.Text;

                var manufacturer = new Manufacturer(id, name);

                LocalDataHolder.Manufacturer_Update(manufacturer);

                ClearManufacturerFields();

                FillData();

                buttonUpdateManufacturer.Text = "Update";
                buttonInsertManufacturer.Enabled = true;
                buttonCancelEditingManufacturer.Enabled = false;
                _editingManufacturer = false;
            }
        }

        private void buttonCancelEditingManufacturer_Click(object sender, EventArgs e)
        {
            if (_editingManufacturer)
            {
                ClearManufacturerFields();

                buttonUpdateManufacturer.Enabled = true;
                buttonUpdateManufacturer.Text = "Update";
                buttonInsertManufacturer.Enabled = true;
                buttonInsertManufacturer.Text = "Insert";
                buttonCancelEditingManufacturer.Enabled = false;

                _editingManufacturer = false;
            }
        }

        private void buttonConvertPartToCode_Click(object sender, EventArgs e)
        {
            if (_selectedPartIndex == -1)
            {
                MessageBox.Show("Select Part");
                return;
            }

            var part = LocalDataHolder.Part_Get(_selectedPartIndex);
            var jsonString =
                JsonConvert.SerializeObject(part);

            ObjectWrapper returnable = new ObjectWrapper();
            ObjectWrapper sendable = new ObjectWrapper(jsonString);

            var hexagonShowForm = new HexagonShowForm(returnable, sendable);
            var thr = new Thread(() => { Application.Run(hexagonShowForm); });
            thr.SetApartmentState(ApartmentState.STA);
            thr.Start();
            this.Visible = false;
            while (!hexagonShowForm.IsDisposed)
            {
                Thread.Sleep(10);
            }
            this.Visible = true;
        }

        private void buttonConvertPartFromCode_Click(object sender, EventArgs e)
        {
            ObjectWrapper returnable = new ObjectWrapper();
            ObjectWrapper sendable = new ObjectWrapper();

            var hexagonParseForm = new HexagonParseForm(returnable, sendable);
            var thr = new Thread(() => { Application.Run(hexagonParseForm); });
            thr.SetApartmentState(ApartmentState.STA);
            thr.Start();
            this.Visible = false;
            while (!hexagonParseForm.IsDisposed)
            {
                Thread.Sleep(10);
            }
            this.Visible = true;
        }
    }
}