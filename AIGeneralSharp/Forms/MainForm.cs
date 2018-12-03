using AIGeneralSharp.Buffer;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AIGeneralSharp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            housesListBox.Items.AddRange(Bindings.Houses);
        }

        private void getBuildPlanButton_Click(object sender, EventArgs e)
        {
            if (selectedHouseTextBox.TextLength > 0)
            {
                // TODO: остановить выполнение, если getHouseInfo не нашёл биндинги
                Bindings.GetHouseInfo(selectedHouseTextBox.Text);
                if (Way.Check().Equals(String.Empty))
                {
                    var text = new StringBuilder();
                    int counter = 0;
                    var wayToTarget = Helper.GetWayToTarget().Reverse().ToList();
                    foreach (var operation in wayToTarget)
                        text.AppendLine($"{++counter}. {operation.Name}");

                    // TODO: подумать, нужно ли делать все эти ContanisKey
                    if (Bindings.OperationsLists.ContainsKey(selectedHouseTextBox.Text))
                        Bindings.OperationsLists.Remove(selectedHouseTextBox.Text);
                    Bindings.OperationsLists.Add(selectedHouseTextBox.Text, wayToTarget);

                    MessageBox.Show(text.ToString(), "План строительства", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show(Way.Check(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("No selected house types.\nPlease, select house type from the list above.",
                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void housesListBox_DoubleClick(object sender, MouseEventArgs e)
        {
            int index = housesListBox.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                selectedHouseTextBox.Text = housesListBox.Items[index].ToString();
            }
        }

        private void getCommonPlanButton_Click(object sender, EventArgs e)
        {
            try
            {
                var commonSteps = Helper.GetCommonSteps();
                var text = Helper.GetCommonConditions(commonSteps);

                MessageBox.Show(text, "Общие пункты планов", MessageBoxButtons.OK);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No plans were found.\nMake at least 2 plans.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
