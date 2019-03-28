using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HexaCode
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private int _selectedPartIndex = -1;

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            LocalDataHolder.RefreshLocalData();
        }

        private void buttonSelectAllParts_Click(object sender, EventArgs e)
        {
            LocalDataHolder.Part_SelectAll().ForEach(part => listBoxParts.Items.Add($"{part.Id}: {part.Name}"));
        }

        private void listBoxParts_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedPartIndex = listBoxParts.SelectedIndex;
            //JToken.Parse("").ToString(Formatting.Indented);
        }
    }
}