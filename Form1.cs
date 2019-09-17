﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG_Program
{
    public partial class CG_Win : Form
    {
        public CG_Win()
        {
            InitializeComponent();
            S_x = 0;
            S_y = 0;
            E_x = 0;
            E_y = 0;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("按下鼠标左键即确定起点，拖动至终点然后松开鼠标左键即可确定终点", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {
            //NULL
        }

        private void GroupBox1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void CG_Win_Load(object sender, EventArgs e)
        {
            groupBox1.MouseDown += new MouseEventHandler(groupBox1_MouseDown);
            groupBox1.MouseUp += new MouseEventHandler(groupBox1_MouseUp);
        }

        void groupBox1_MouseDown(object sender,MouseEventArgs e)
        {
            S_x = e.X;
            if (e.Y <= 10)
                S_y = this.groupBox1.Height -10;
            else
            S_y = this.groupBox1.Height-e.Y;
        }
        void groupBox1_MouseUp(object sender, MouseEventArgs e)
        {
            E_x = e.X;
            if(e.Y<=10)
                E_y = this.groupBox1.Height - 10;
            else
            E_y = this.groupBox1.Height-e.Y;
            //MessageBox.Show("1:" + S_x + "   2:" + S_y + "   3:" + E_x + "   4:" + E_y);
            GroupBox1_Paint(null,null) ;
        }

        private void GroupBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics_Line = this.groupBox1.CreateGraphics();
            Pen LinePen = new Pen(Color.FromArgb(174, 189, 191), 1);
            int tmp;
            if(E_x<=S_x)
            {
                tmp = E_x;
                E_x = S_x;
                S_x = tmp;

                tmp = E_y;
                E_y = S_y;
                S_y = tmp;
            }
            int det_x, det_y,line_e,x,y;
            det_x = E_x - S_x;
            det_y = E_y - S_y;
            line_e = 0-det_x;
            x = S_x;
            y = S_y;
            if(det_y<0)
            {
                S_y = this.groupBox1.Height - S_y;
                E_y = this.groupBox1.Height - E_y;
                x = S_x;
                y = S_y;
                //MessageBox.Show("1:" + S_x + "   2:" + S_y + "   3:" + E_x + "   4:" + E_y);
                det_y = 0 - det_y;
                if (det_x >= det_y)
                {
                    for (int i = 0; i <= det_x; i++)
                    {
                        graphics_Line.DrawLine(LinePen, x, y, x + 1, y + 1);
                        //MessageBox.Show("e" + line_e); 
                        x++;
                        line_e = line_e + 2 * det_y;
                        if (line_e >= 0)
                        {
                            y++;
                            line_e = line_e - 2 * det_x;
                            //MessageBox.Show("e" + line_e);
                        }

                    }
                }
                else
                {
                    line_e = 0 - det_y;
                    for (int i = 0; i <= det_y; i++)
                    {
                        graphics_Line.DrawLine(LinePen, x, y, x + 1, y + 1);
                        //MessageBox.Show("e" + line_e); 
                        y++;
                        line_e = line_e + 2 * det_x;
                        if (line_e >= 0)
                        {
                            x++;
                            line_e = line_e - 2 * det_y;
                            //MessageBox.Show("e" + line_e);
                        }

                    }
                }
            }
            else
            {
                if (det_x >= det_y)
                {
                    for (int i = 0; i <= det_x; i++)
                    {
                        graphics_Line.DrawLine(LinePen, x, this.groupBox1.Height - y, x + 1, this.groupBox1.Height - y - 1);
                        //MessageBox.Show("e" + line_e); 
                        x++;
                        line_e = line_e + 2 * det_y;
                        if (line_e >= 0)
                        {
                            y++;
                            line_e = line_e - 2 * det_x;
                            //MessageBox.Show("e" + line_e);
                        }

                    }
                }
                else
                {
                    line_e = 0 - det_y;
                    for (int i = 0; i <= det_y; i++)
                    {
                        graphics_Line.DrawLine(LinePen, x, this.groupBox1.Height - y, x + 1, this.groupBox1.Height - y - 1);
                        //MessageBox.Show("e" + line_e); 
                        y++;
                        line_e = line_e + 2 * det_x;
                        if (line_e >= 0)
                        {
                            x++;
                            line_e = line_e - 2 * det_y;
                            //MessageBox.Show("e" + line_e);
                        }

                    }
                }
            }



        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Graphics graphics_Line = this.groupBox1.CreateGraphics();
            Pen LinePen = new Pen(Color.FromArgb(255,255,255), 1);
            for(int i=10;i<=this.groupBox1.Height;i++)
            {
                graphics_Line.DrawLine(LinePen, 1,i,this.groupBox1.Width,i);
            }
        }
    }
}