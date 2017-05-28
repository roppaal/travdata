using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravPeg
{
    public static class CommonDGV  //Common Data Grid View
    {
        internal static void LinkTableToGridColumns(DataView v, DataGridView g)
        {
            for (int i = 0; i < g.ColumnCount; i++)
            {
                g.Columns[g.Columns[i].HeaderText].DataPropertyName = g.Columns[i].HeaderText;
            }
        }

        internal static void Set_DBGridColumns(DataGridView dbg)
        {
            for (int i = 0; i < dbg.Columns.Count; i++)
            {
                if ((dbg.Columns[i].ValueType == typeof(double)) || (dbg.Columns[i].ValueType == typeof(float)))
                {
                    if ((dbg.Columns[i].HeaderText.Contains("Bear")) || (dbg.Columns[i].HeaderText.Contains("HA")) || (dbg.Columns[i].HeaderText.Contains("VA")) || (dbg.Columns[i].HeaderText.Contains("Dip")))
                    {
                        dbg.Columns[i].DefaultCellStyle.Format = "N4";
                    }
                    else
                    {
                        dbg.Columns[i].DefaultCellStyle.Format = "N3";
                    }
                    dbg.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                if ((dbg.Columns[i].ValueType == typeof(Int16)) || (dbg.Columns[i].ValueType == typeof(Int32)) || (dbg.Columns[i].ValueType == typeof(Int64)))
                {
                    dbg.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        internal static void KeyDown(object sender, KeyEventArgs e)
        {  //http://stackoverflow.com/questions/9666657/how-to-move-focus-on-next-cell-in-a-datagridview-on-enter-key-press-event
            if (e.KeyCode == Keys.Enter)
            {
                int rcnt = ((DataGridView)sender).Rows.Count - 1 - 1;
                int ccnt = ((DataGridView)sender).Columns.Count - 1;
                int r = ((DataGridView)sender).CurrentCell.RowIndex;
                int c = ((DataGridView)sender).CurrentCell.ColumnIndex;
                if (c < ccnt)
                {
                    c++;
                }
                else
                {
                    c = 0;
                    if (r < rcnt) { r++; }
                }

                ((DataGridView)sender).CurrentCell = ((DataGridView)sender)[c, r];
                e.Handled = true;
                return;
            }
        }

        internal static void CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
            KeyEventArgs forKeyDown = new KeyEventArgs(Keys.Enter);
            KeyDown(((DataGridView)sender), forKeyDown);
            SendKeys.Send("{up}");
        }
    }
}
