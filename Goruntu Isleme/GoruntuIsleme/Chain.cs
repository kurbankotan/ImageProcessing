using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

public class Form4 : Form
{
    private const Int32 xSize = 11;
    private const Int32 ySize = 12;
    private chaincode cc = new chaincode();
    private Int32 i, x, y, dx, dy;
    private Byte[,] i0 = new Byte[ySize, xSize];
    private Boolean NullCells;
    private Point start;
    private readonly ArrayList all_chaincodes = new ArrayList();
    private readonly Font arial10 = new Font("Arial", 10);
    private readonly Brush blackbrush = SystemBrushes.ControlText;
    private readonly Brush bluebrush = new SolidBrush(Color.Blue);
    private readonly Brush[] brush = new Brush[10];
    private readonly Button[] button = new Button[ySize];
    private readonly Byte[,] c1v = new Byte[ySize, xSize + 1];
    private readonly Pen pinkpen = new Pen(Color.FromArgb(255, 128, 128), 3);
    private readonly Pen redpen = new Pen(Color.Red, 5);
    private readonly Byte threshold = 1;

    public Form4()
    {
        BackColor = Color.White;
        Text = "Chain Code";
        for (i = 0; i < 10; i++)
            brush[i] = new SolidBrush(Color.FromArgb(i*25, i*25, i*25));
        for (y = 0; y < ySize; y++)
        {
            button[y] = new Button();
            Controls.Add(button[y]);
            button[y].BackColor = Color.Gray;
            button[y].Text = "Button" + y;
            button[y].Name = y.ToString();
            button[y].Click += do_it;
        }
        button[0].Name = button[0].Text = @"Çiz";
        button[1].Name = button[1].Text = @"Hesapla";
        button[2].Name = button[2].Text = @"Çıkış";
        redpen.EndCap = LineCap.ArrowAnchor;
        pinkpen.EndCap = LineCap.ArrowAnchor;
        SetStyle(ControlStyles.ResizeRedraw, true);
        Width = 800;
        Height = 600;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        var r = ClientRectangle;
        dx = r.Width/(xSize + 2);
        dy = (r.Height - all_chaincodes.Count*FontHeight)/ySize;
        for (y = 0; y < ySize; y++)
        {
            button[y].Top = y*dy + 1;
            button[y].Left = xSize*dx + 1;
            button[y].Width = r.Width - button[y].Left - 2;
            button[y].Height = dy - 2;
        }
        var textfieldY = button[ySize - 1].Top + button[ySize - 1].Height + 2;

        for (y = 0; y < ySize; y++)
            for (x = 0; x < xSize; x++)
                g.FillRectangle(brush[i0[y, x]], x*dx, y*dy, dx, dy);
        if (all_chaincodes.Count == 0) return;
        for (i = 0; i < all_chaincodes.Count; i++)
        {
            var c = (chaincode) all_chaincodes[i];
            x = c.start.X;
            y = c.start.Y;
            for (var ii = 0; ii < c.perimeter; ii++)
                switch (c.cracks[ii])
                {
                    case 'e':
                        g.DrawLine(redpen, x*dx, y*dy, (x + 1)*dx, y*dy);
                        x++;
                        break;
                    case 's':
                        g.DrawLine(redpen, x*dx, y*dy, x*dx, (y + 1)*dy);
                        y++;
                        break;
                    case 'w':
                        g.DrawLine(redpen, x*dx, y*dy, (x - 1)*dx, y*dy);
                        x--;
                        break;
                    case 'n':
                        g.DrawLine(redpen, x*dx, y*dy, x*dx, (y - 1)*dy);
                        y--;
                        break;
                }
            g.FillRectangle(bluebrush, x*dx - 5, y*dy - 5, 11, 11);
            var s = "(" + c.start.X + "/" +
                    c.start.Y + ")" +
                    c.cracks + "  P=" +
                    c.perimeter + "  A=" +
                    c.area;
            if (c.area < 0) s += " =negative";
            g.DrawString(s, arial10, blackbrush, 0, textfieldY);
            textfieldY += FontHeight;
        }
    }

    protected void do_it(object sender, EventArgs e)
    {
        switch (((Button) sender).Name)
        {
            case "Çiz": //***********************************
                i0 = new Byte[,]
                {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {0, 2, 0, 0, 9, 9, 9, 0, 0, 0, 0},
                    {0, 2, 0, 0, 9, 0, 9, 0, 0, 0, 0},
                    {2, 2, 2, 0, 9, 8, 9, 0, 0, 0, 0},
                    {0, 2, 0, 0, 0, 7, 0, 0, 0, 2, 0},
                    {0, 0, 6, 6, 6, 6, 6, 6, 6, 0, 0},
                    {0, 0, 0, 0, 5, 5, 5, 0, 0, 0, 0},
                    {0, 0, 0, 0, 4, 4, 4, 0, 0, 0, 0},
                    {0, 0, 0, 0, 3, 0, 3, 0, 0, 0, 0},
                    {0, 0, 0, 0, 2, 0, 2, 0, 0, 0, 0},
                    {0, 0, 0, 0, 2, 0, 0, 2, 0, 0, 0},
                    {0, 0, 0, 2, 2, 0, 0, 2, 2, 0, 0}
                };
                all_chaincodes.Clear();
                break;
            case "Hesapla":
                NullCells = true;
                all_chaincodes.Clear();
                Invalidate();
                Application.DoEvents();
                chaincode_finder();
                break;
            case "Çıkış":
                var form4 = new Form4();
                form4.Close();
                break;
        }
        Invalidate();
    }

    private void chaincode_finder()
    {
        SByte[,] negative = {{0, -1}, {0, 0}, {-1, 0}, {-1, -1}};
        SByte[,] positive = {{0, 0}, {-1, 0}, {-1, -1}, {0, -1}};
        Point neg = new Point(), pos = new Point();
        for (y = 0; y < ySize; y++)
            for (x = 0; x <= xSize; x++) c1v[y, x] = 0;
        start.X = start.Y = 0;
        for (Byte ccNo = 1; start_crack_search(); ccNo++)
        {
            var chaincode = new chaincode();
            var cracks = new StringBuilder();
            chaincode.start = start;
            cracks.Append('s');
            chaincode.area = 0;
            x = start.X;
            y = start.Y + 1;
            var direction = 1;
            var g = CreateGraphics();
            Boolean NEG;
            do
            {
                g.DrawLine(pinkpen, x*dx, y*dy, x*dx + dx/4, y*dy);
                g.DrawLine(pinkpen, x*dx, y*dy, x*dx, y*dy + dy/4);
                g.DrawLine(pinkpen, x*dx, y*dy, x*dx - dx/4, y*dy);
                g.DrawLine(pinkpen, x*dx, y*dy, x*dx, y*dy - dy/4);
                switch (direction) //last crack
                {
                    case 0:
                        g.DrawLine(redpen, (x - 1)*dx, y*dy, x*dx, y*dy);
                        break;
                    case 1:
                        g.DrawLine(redpen, x*dx, (y - 1)*dy, x*dx, y*dy);
                        break;
                    case 2:
                        g.DrawLine(redpen, (x + 1)*dx, y*dy, x*dx, y*dy);
                        break;
                    case 3:
                        g.DrawLine(redpen, x*dx, (y + 1)*dy, x*dx, y*dy);
                        break;
                }
                var ticks = DateTime.Now.Ticks + 20000;
                do
                {
                } while (ticks > DateTime.Now.Ticks);
                neg.X = x + negative[direction, 0];
                neg.Y = y + negative[direction, 1];
                pos.X = x + positive[direction, 0];
                pos.Y = y + positive[direction, 1];
                try
                {
                    NEG = i0[neg.Y, neg.X] >= threshold;
                }
                catch
                {
                    NEG = false;
                }
                Boolean POS;
                try
                {
                    POS = i0[pos.Y, pos.X] >= threshold;
                }
                catch
                {
                    POS = false;
                }
                if (POS && (NEG || NullCells)) direction = (direction + 1)%4;
                else if (!NEG && (!POS || !NullCells)) direction = (direction + 3)%4;
                switch (direction)
                {
                    case 0:
                        cracks.Append('e');
                        x++;
                        chaincode.area += y;
                        break;
                    case 1:
                        cracks.Append('s');
                        y++;
                        c1v[y - 1, x] = ccNo;
                        break;
                    case 2:
                        cracks.Append('w');
                        x--;
                        chaincode.area -= y;
                        break;
                    case 3:
                        cracks.Append('n');
                        y--;
                        c1v[y, x] = ccNo;
                        break;
                }
            } while (x != start.X || y != start.Y); //end of do
            switch (direction) //draw the final crack
            {
                case 0:
                    g.DrawLine(redpen, (x - 1)*dx, y*dy, x*dx, y*dy);
                    break;
                case 2:
                    g.DrawLine(redpen, (x + 1)*dx, y*dy, x*dx, y*dy);
                    break;
            }
            chaincode.cracks = cracks.ToString();
            chaincode.perimeter = chaincode.cracks.Length;
            all_chaincodes.Add(chaincode);
        } // end of for
    }

    private Boolean start_crack_search()
    {
        for (y = start.Y; y < ySize; y++)
            for (x = 0; x < xSize; x++)
            {
                Byte left;
                if (x > 0) left = i0[y, x - 1];
                else left = 0;
                if (left < threshold && i0[y, x] >= threshold && c1v[y, x] == 0)
                {
                    start.X = x;
                    start.Y = y;
                    c1v[y, x] = 1;
                    return true;
                }
            }
        return false;
    }

    private class chaincode
    {
        public String cracks;
        public Int32 perimeter, area;
        public Point start;
    }
}