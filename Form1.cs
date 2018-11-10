using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleTCP;
using System.IO;
using System.Threading;




namespace Position
{
    public partial class Form1 : Form
    {
        SimpleTcpServer server;
        int clock = 1;
        int a = 0;
        int c = 0;
        double PositionX_avg = 0;
        double PositionY_avg = 0;
        double[] PositionX_mov_avg = new double[5];
        double[] PositionY_mov_avg = new double[5];
        int timer_clk = 0;
        int check_TAG = 0;
        int check_ANCHOR_1 = 0;
        int check_ANCHOR_2 = 0;
        int check_ANCHOR_3 = 0;
        ulong[] Tag_Dec = new ulong[3];
        ulong[] Anchor_Dec_1 = new ulong[3];
        ulong[] Anchor_Dec_2 = new ulong[3];
        ulong[] Anchor_Dec_3 = new ulong[3];
        bool ERROR = false;
        bool first_avg = false;
        string mydocpath =
    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        int wynik;
        double[] StatX = new double[500];
        double[] StatY = new double[500];
        double[] PosXY = new double[2];
        int Error_mm = 300;
        int Count = 0;
        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            server = new SimpleTcpServer();
            server.Delimiter = 0x13; //Enter
            server.StringEncoder = Encoding.UTF8;
            server.DataReceived += Server_DataReceived;

        }
        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            Receiving_text.Invoke((MethodInvoker)delegate ()
            {
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(mydocpath, "Distance_log.txt"), true))
                {
                    outputFile.WriteLine("TAG = " + check_TAG.ToString() + " ANCHOR1 = " + check_ANCHOR_1 + " ANCHOR2 = " + check_ANCHOR_2
                        + " ANCHOR3 = " + check_ANCHOR_3);
                }
                Receiving_text.Text = e.MessageString;
                Data_Convertion(sender);
                int.TryParse(Max_val_txt.Text, out int max_val);
                if (check_TAG == 1 && check_ANCHOR_1 == 1)
                {
                    double distance = Distance(Anchor_Dec_1, Tag_Dec);
                    if (distance > 0 && distance < max_val)
                    {
                       R1_text.Text = string.Format("{0:F2}", distance);
                        using (StreamWriter outputFile = new StreamWriter(Path.Combine(mydocpath, "DistanceANCHOR1_log.txt"), true))
                        {
                            outputFile.WriteLine(R1_text.Text);
                        }
                        check_ANCHOR_1 = 0;
                        check_TAG = 0;
                        ERROR = false;
                    }
                    else
                    {
                        ERROR = false;
                        Reset_DWM(sender);
                    }

                }
                if (check_TAG == 1 && check_ANCHOR_2 == 1)
                {
                    double distance = Distance(Anchor_Dec_2, Tag_Dec);
                    if (distance > 0 && distance < max_val)
                    {
                       R2_text.Text = string.Format("{0:F2}", distance);
                        using (StreamWriter outputFile = new StreamWriter(Path.Combine(mydocpath, "DistanceANCHOR2_log.txt"), true))
                        {
                            outputFile.WriteLine(R2_text.Text + "     TAG = " + check_TAG.ToString() + " ANCHOR1 = " + check_ANCHOR_1 + " ANCHOR2 = " + check_ANCHOR_2
                            + " ANCHOR3 = " + check_ANCHOR_3);
                        }
                        check_ANCHOR_2 = 0;
                        check_TAG = 0;
                        ERROR = false;
                    }
                    else
                    {
                        ERROR = false;
                        Reset_DWM(sender);
                    }
                }
                if (check_TAG == 1 && check_ANCHOR_3 == 1)
                {
                    double distance = Distance(Anchor_Dec_3, Tag_Dec);
                    if (distance > 0 && distance < max_val)
                    {
                        R3_text.Text = string.Format("{0:F2}", distance);
                        using (StreamWriter outputFile = new StreamWriter(Path.Combine(mydocpath, "DistanceANCHOR3_log.txt"), true))
                        {
                            outputFile.WriteLine(R3_text.Text + "     TAG = " + check_TAG.ToString() + " ANCHOR1 = " + check_ANCHOR_1 + " ANCHOR2 = " + check_ANCHOR_2
                            + " ANCHOR3 = " + check_ANCHOR_3);
                        }
                        check_ANCHOR_3 = 0;
                        check_TAG = 0;
                        ERROR = false;
                        ERROR = true;
                        ERROR = false;
                        if (Trilateration.Checked == true)
                        Pomiar();
                    }
                    else
                    {
                        ERROR = false;
                        Reset_DWM(sender);
                    }
                }

                // e.ReplyLine(string.Format("You said {0}", e.MessageString));
                //  e.TcpClient.
            });
        }
        private void Data_Convertion(object sender)
        {
            string Dev_1 = "Device_1:";
            string Dev_2 = "Device_2:";
            string Dev_3 = "Device_3:";
            string Dev_4 = "Device_4:";
            if (Receiving_text.Text.StartsWith(Dev_1))
            {
                int chunkSize_TAG = 10;
                int stringLength_TAG = 30;
                int Data_count_TAG = stringLength_TAG / chunkSize_TAG;
                string[] TAG_Hex = new string[Data_count_TAG];
                char[] TMP_String = new char[30];
                string TMP_String1;
                TMP_String1 = Receiving_text.Text;
                for (int i = 9; i < 39; i++)
                {
                    TMP_String[i - 9] = TMP_String1[i];
                }
                string tmp = new string(TMP_String);
                for (int i = 0; i < (stringLength_TAG); i += chunkSize_TAG)
                {
                    if (i + chunkSize_TAG > stringLength_TAG) chunkSize_TAG = stringLength_TAG - i;
                    TAG_Hex[(i) / 10] = tmp.Substring(i, chunkSize_TAG);

                }
                for (int i = 0; i < Data_count_TAG; i++)
                {
                    Tag_Dec[i] = ulong.Parse(TAG_Hex[i], System.Globalization.NumberStyles.HexNumber);
                }
                check_TAG = 1;
            }
            if (Receiving_text.Text.StartsWith(Dev_2))
            {
                int chunkSize_ANCHOR = 10;
                int stringLength_ANCHOR = 30;
                int Data_count_ANCHOR = stringLength_ANCHOR / chunkSize_ANCHOR;
                string[] ANCHOR_Hex = new string[Data_count_ANCHOR];
                char[] TMP_String = new char[30];
                string TMP_String1;
                TMP_String1 = Receiving_text.Text;
                for (int i = 9; i < 39; i++)
                {
                    TMP_String[i - 9] = TMP_String1[i];
                }
                string tmp = new string(TMP_String);

                for (int i = 0; i < stringLength_ANCHOR; i += chunkSize_ANCHOR)
                {
                    if (i + chunkSize_ANCHOR > stringLength_ANCHOR) chunkSize_ANCHOR = stringLength_ANCHOR - i;
                    ANCHOR_Hex[(i) / 10] = tmp.Substring(i, chunkSize_ANCHOR);
                }
                for (int i = 0; i < Data_count_ANCHOR; i++)
                {
                    Anchor_Dec_1[i] = ulong.Parse(ANCHOR_Hex[i], System.Globalization.NumberStyles.HexNumber);
                }
                check_ANCHOR_1 = 1;
            }
            if (Receiving_text.Text.StartsWith(Dev_3))
            {
                int chunkSize_ANCHOR = 10;
                int stringLength_ANCHOR = 30;
                int Data_count_ANCHOR = stringLength_ANCHOR / chunkSize_ANCHOR;
                string[] ANCHOR_Hex = new string[Data_count_ANCHOR];
                char[] TMP_String = new char[30];
                string TMP_String1;
                TMP_String1 = Receiving_text.Text;
                for (int i = 9; i < 39; i++)
                {
                    TMP_String[i - 9] = TMP_String1[i];
                }
                string tmp = new string(TMP_String);

                for (int i = 0; i < stringLength_ANCHOR; i += chunkSize_ANCHOR)
                {
                    if (i + chunkSize_ANCHOR > stringLength_ANCHOR) chunkSize_ANCHOR = stringLength_ANCHOR - i;
                    ANCHOR_Hex[(i) / 10] = tmp.Substring(i, chunkSize_ANCHOR);
                }
                for (int i = 0; i < Data_count_ANCHOR; i++)
                {
                    Anchor_Dec_2[i] = ulong.Parse(ANCHOR_Hex[i], System.Globalization.NumberStyles.HexNumber);
                }
                check_ANCHOR_2 = 1;
            }
            if (Receiving_text.Text.StartsWith(Dev_4))
            {
                int chunkSize_ANCHOR = 10;
                int stringLength_ANCHOR = 30;
                int Data_count_ANCHOR = stringLength_ANCHOR / chunkSize_ANCHOR;
                string[] ANCHOR_Hex = new string[Data_count_ANCHOR];
                char[] TMP_String = new char[30];
                string TMP_String1;
                TMP_String1 = Receiving_text.Text;
                for (int i = 9; i < 39; i++)
                {
                    TMP_String[i - 9] = TMP_String1[i];
                }
                string tmp = new string(TMP_String);

                for (int i = 0; i < stringLength_ANCHOR; i += chunkSize_ANCHOR)
                {
                    if (i + chunkSize_ANCHOR > stringLength_ANCHOR) chunkSize_ANCHOR = stringLength_ANCHOR - i;
                    ANCHOR_Hex[(i) / 10] = tmp.Substring(i, chunkSize_ANCHOR);
                }
                for (int i = 0; i < Data_count_ANCHOR; i++)
                {
                    Anchor_Dec_3[i] = ulong.Parse(ANCHOR_Hex[i], System.Globalization.NumberStyles.HexNumber);
                }
                check_ANCHOR_3 = 1;
            }
        }
        private void Reset_DWM(object sender)
        {
            clock = 1;
            check_TAG = 0;
            check_ANCHOR_1 = 0;
            check_ANCHOR_2 = 0;
            check_ANCHOR_3 = 0;
            Array.Clear(Tag_Dec, 0, Tag_Dec.Length);
            Array.Clear(Anchor_Dec_1, 0, Anchor_Dec_1.Length);
            Array.Clear(Anchor_Dec_2, 0, Anchor_Dec_2.Length);
            Array.Clear(Anchor_Dec_3, 0, Anchor_Dec_3.Length);
            ERROR = false;
        }
        private double Distance(ulong[] Anchor_Dec, ulong[] Tag_Dec)
        {
            double Round1, Round2, Reply1, Reply2;
            double distance;
            double Calib = 124.39;
            double SpeedOfLight = 299792458;

            Round1 = (Tag_Dec[1] - Tag_Dec[0]);
            Round2 = (Anchor_Dec[2] - Anchor_Dec[1]);
            Reply1 = (Anchor_Dec[1] - Anchor_Dec[0]);
            Reply2 = (Tag_Dec[2] - Tag_Dec[1]);
            distance = (Round1 * Round2 - Reply1 * Reply2) / (Round1 + Round2 + Reply1 + Reply2) * SpeedOfLight * Math.Pow(10, -12) * 12.65 - Calib;
            if (distance > 2)
                distance += 0.1774 * distance - 0.359;
            return distance;
        }
        unsafe public int Circle_circle_intersection(double x0, double y0, double r0,
            double x1, double y1, double r1,
            double* xi, double* yi,
            double* xi_prime, double* yi_prime)
        {
            double a, dx, dy, d, h, rx, ry;
            double x2, y2;

            /* dx and dy are the vertical and horizontal distances between
            * the circle centers.
            */
            dx = x1 - x0;
            dy = y1 - y0;

            /* Determine the straight-line distance between the centers. */
            //d = sqrt((dy*dy) + (dx*dx));
            d = Math.Sqrt(dx*dx+dy*dy); // Suggested by Keith Briggs

            /* Check for solvability. */
            if (d > (r0 + r1))
            {
                /* no solution. circles do not intersect. */
                return 0;
            }
            if (d < Math.Abs(r0 - r1))
            {
                /* no solution. one circle is contained in the other */
                return 0;
            }

            /* 'point 2' is the point where the line through the circle
            * intersection points crosses the line between the circle
            * centers.
            */

            /* Determine the distance from point 0 to point 2. */
            a = ((r0 * r0) - (r1 * r1) + (d * d)) / (2.0 * d);

            /* Determine the coordinates of point 2. */
            x2 = x0 + (dx * a / d);
            y2 = y0 + (dy * a / d);

            /* Determine the distance from point 2 to either of the
            * intersection points.
            */
            h = Math.Sqrt((r0 * r0) - (a * a));

            /* Now determine the offsets of the intersection points from
            * point 2.
            */
            rx = -dy * (h / d);
            ry = dx * (h / d);

            /* Determine the absolute intersection points. */
            *xi = x2 + rx;
            *xi_prime = x2 - rx;
            *yi = y2 + ry;
            *yi_prime = y2 - ry;
            if (*xi == *xi_prime && *yi == *yi_prime)
                return 1;
            else
                return 2;
        }

        unsafe public double[] Run_test(double x0, double y0, double r0,
            double x1, double y1, double r1)
        {
            double[] Points = new double[4];
            double[] Point = new double[2];
            double x3, y3, x3_prime, y3_prime;
            int R0_ERROR = 0;
            wynik = Circle_circle_intersection(x0, y0, r0, x1, y1, r1,
                &x3, &y3, &x3_prime, &y3_prime);
            while (wynik == 0)

            {
                R0_ERROR++;
                r1++;
                wynik = Circle_circle_intersection(x0, y0, r0, x1, y1, r1,
                  &x3, &y3, &x3_prime, &y3_prime);
                if (R0_ERROR >= 1000)
                    break;
            }
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(mydocpath, "Errors.txt"), true))
            {
                outputFile.WriteLine("Blad intersekcji :" + R0_ERROR.ToString());
            }
            Points[0] =x3;
                Points[1] = y3;
                Points[2] = x3_prime;
                Points[3] = y3_prime;
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(mydocpath, "punkciki.txt"), true))
            {
                outputFile.WriteLine("Circle points: X = " + x3.ToString() + " Y = " + y3.ToString() +
                    " X = " + x3_prime.ToString() + " Y = " + y3_prime.ToString());
            }

            string x0_txt = x0.ToString();
            string y0_txt = y0.ToString();
            string r0_txt = r0.ToString();
            string x1_txt = x1.ToString();
            string y1_txt = y1.ToString();
            string r1_txt = r1.ToString();
            string x3_txt = x3.ToString();
            string y3_txt = y3.ToString();
            string x4_txt = x3_prime.ToString();
            string y4_txt = y3_prime.ToString();
            string R0_ERROR_txt = R0_ERROR.ToString();
            //Wynik_txt(x0_txt, y0_txt, r0_txt, x1_txt, y1_txt, r1_txt, x3_txt, y3_txt, x4_txt, y4_txt, R0_ERROR_txt, wynik);
            return Points;
        }
        public void Wynik_txt(string x0, string y0, string r0, string x1, string y1,
                                string r1, string x3, string y3, string x4, string y4,string error, int wynik)
        {

                textBox1.AppendText("\r(x1,y1,r1) = (");
                textBox1.AppendText(x0);
                textBox1.AppendText(",");
                textBox1.AppendText(y0);
                textBox1.AppendText(",");
                textBox1.AppendText(r0);
                textBox1.AppendText(")\r");
                textBox1.AppendText("(x2,y2,r2) = (");
                textBox1.AppendText(x1);
                textBox1.AppendText(",");
                textBox1.AppendText(y1);
                textBox1.AppendText(",");
                textBox1.AppendText(r1);
                textBox1.AppendText(")\r");
                textBox1.AppendText("(x3,y3) = (");
                textBox1.AppendText(x3);
                textBox1.AppendText(",");
                textBox1.AppendText(y3);
                textBox1.AppendText(")\r");
            if (wynik == 2)
            {
                textBox1.AppendText("(x4,y4) = (");
                textBox1.AppendText(x4);
                textBox1.AppendText(",");
                textBox1.AppendText(y4);
                textBox1.AppendText(")\r");
            }
            textBox1.AppendText("Error = ");
            textBox1.AppendText(error);
            textBox1.AppendText("\r");

        }
        private void button1_Click(object sender, EventArgs e)
        {
            double x1, y1, r1, x2, y2, r2, x3, y3, r3;
            double[] D_Points = new double[4];
            double[] X_Points = new double[6];
            double[] Y_Points = new double[6];
            double[] X_Points_Calib = new double[6];
            double[] Y_Points_Calib = new double[6];
            int i = 0, ile = 0,Pop_wynik = 0;
            x1 = Convert.ToDouble(X1_text.Text);
            y1 = Convert.ToDouble(Y1_text.Text);
            r1 = Convert.ToDouble(R1_text.Text) * 1000;
            x2 = Convert.ToDouble(X2_text.Text);
            y2 = Convert.ToDouble(Y2_text.Text);
            r2 = Convert.ToDouble(R2_text.Text)* 1000 ;
            x3 = Convert.ToDouble(X3_text.Text);
            y3 = Convert.ToDouble(Y3_text.Text);
            r3 = Convert.ToDouble(R3_text.Text)* 1000;
            Wykres.Series["Kotwica"].Points.Clear();
            Wykres.Series["Obliczenia"].Points.Clear();
          //  Wykres.Series["Pozycja"].Points.Clear();
            Wykres.ChartAreas["ChartArea1"].AxisX.Minimum = -1000;
            Wykres.ChartAreas["ChartArea1"].AxisX.Maximum = 2500;
            Wykres.ChartAreas["ChartArea1"].AxisY.Minimum = -1000;
            Wykres.ChartAreas["ChartArea1"].AxisY.Maximum = 4000;
            Wykres.Series["Kotwica"].Points.AddXY(x1, y1);
            Wykres.Series["Kotwica"].Points.AddXY(x2, y2);
            Wykres.Series["Kotwica"].Points.AddXY(x3, y3);

           // textBox1.AppendText("1->2");
            D_Points = Run_test(x1,y1,r1,x2,y2,r2);
            if (wynik == 1)
            {
                X_Points[i] = D_Points[0];
                Y_Points[i] = D_Points[1];
                i++;
                ile++;
                Pop_wynik = wynik;
            }
            if(wynik == 2)
            {
                X_Points[i] = D_Points[0];
                Y_Points[i] = D_Points[1];
                X_Points[i + 1] = D_Points[2];
                Y_Points[i + 1] = D_Points[3];
                i++;
                ile += 2;
                Pop_wynik = wynik;
            }
          //  textBox1.AppendText("2->3");
            D_Points = Run_test(x2, y2, r2, x3, y3, r3);
            if (wynik == 1)
            {
                if (Pop_wynik == 2) i++;
                X_Points[i] = D_Points[0];
                Y_Points[i] = D_Points[1];
                i++;
                ile++;
                Pop_wynik = wynik;
            }
            if (wynik == 2)
            {
                if (Pop_wynik == 2) i++;
                X_Points[i] = D_Points[0];
                Y_Points[i] = D_Points[1];
                X_Points[i + 1] = D_Points[2];
                Y_Points[i + 1] = D_Points[3];
                i++;
                ile += 2;
                Pop_wynik = wynik;
            }
           // textBox1.AppendText("3->1");
            D_Points = Run_test(x1, y1, r1, x3, y3, r3);
            if (wynik == 1)
            {
                if (Pop_wynik == 2) i++;
                X_Points[i] = D_Points[0];
                Y_Points[i] = D_Points[1];
                i++;
                ile++;
            }
            if (wynik == 2)
            {
                if (Pop_wynik == 2) i++;
                X_Points[i] = D_Points[0];
                Y_Points[i] = D_Points[1];
                X_Points[i + 1] = D_Points[2];
                Y_Points[i + 1] = D_Points[3];
                i++;
                ile += 2;
            }
            double tmpX=0, tmpY=0;
            int ile_calib = Calibration(X_Points, Y_Points, X_Points_Calib, Y_Points_Calib, ile);
            for(int j = 0; j < ile_calib; j++)
            {
                Wykres.Series["Obliczenia"].Points.AddXY(Math.Truncate(X_Points_Calib[j]), Math.Truncate(Y_Points_Calib[j]));
                tmpX += X_Points_Calib[j];
                tmpY += Y_Points_Calib[j];
            }
            double PositionX = Math.Truncate(tmpX / ile_calib);
            double PositionY = Math.Truncate(tmpY / ile_calib);
            PosXY[0] = PositionX;
            PosXY[1] = PositionY;
            textBox1.Clear();
            textBox1.AppendText("(x,y) = (");
            textBox1.AppendText(PositionX.ToString());
            textBox1.AppendText(",");
            textBox1.AppendText(PositionY.ToString());
            textBox1.AppendText(")\r");
            Wykres.Series["Pozycja"].Points.AddXY(PositionX, PositionY);

        }

        public int Calibration(double[] X_Points, double[] Y_Points, double[] X_Points_Calib, double[] Y_Points_Calib, int count)
        {
            int X_Calib;
            int Y_Calib;
            Int32.TryParse(X_CALIB.Text,out X_Calib);
            Int32.TryParse(Y_CALIB.Text, out Y_Calib);
            double ERROR = 1000000;
            int OK_X = 2;
            int OK_Y = 2;
            int z = 0;

            for (int i = 0; i < count; i++)
            {
                OK_X = 0;
                OK_Y = 0;
                for (int j = 0; j < count; j++)
                {
                    if(i != j)
                    {
                        z = 0;
                        OK_X = 0;
                        OK_Y = 0;
                        if (X_Points[i] != ERROR && X_Points[j] != ERROR)
                        {
                            if (X_Points[i] + X_Calib >= X_Points[j] && X_Points[i] - X_Calib <= X_Points[j])
                                OK_X = 1;
                        }
                        else
                            z = 1;
                        if (Y_Points[i] != ERROR && Y_Points[j] != ERROR)
                        {
                            if (Y_Points[i] + Y_Calib >= Y_Points[j] && Y_Points[i] - Y_Calib <= Y_Points[j])
                                OK_Y = 1;
                        }
                        else
                            z = 1;
                        if( z != 1)
                            if (OK_X == 0 || OK_Y == 0)
                        {
                            X_Points[j] = ERROR;
                            Y_Points[j] = ERROR;
                        }
                    }
                }
            }

            int tmp = 0;
            for (int i = 0; i < count; i++)
            {
                if(X_Points[i] != ERROR)
                {
                    X_Points_Calib[tmp] = X_Points[i];
                    Y_Points_Calib[tmp] = Y_Points[i];
                    tmp++;
                }
            }
            return tmp;

        }
        private double getStandardDeviation(List<double> doubleList)
        {
            double average = doubleList.Average();
            double sumOfDerivation = 0;
            foreach (double value in doubleList)
            {
                sumOfDerivation += (value) * (value);
            }
            double sumOfDerivationAverage = sumOfDerivation / (doubleList.Count - 1);
            return Math.Sqrt(sumOfDerivationAverage - (average * average));
        }
        private void button2_Click(object sender, EventArgs e)
        {

            double[] TempXY = new double[2];
            double[] PositionXY = new double[10];
            double Final_POS_X = 0;
            double Final_POS_Y = 0;
            Random random = new Random();
            string R1_Rand = random.Next(5408-Error_mm, 5408+Error_mm).ToString();
            string R2_Rand = random.Next(4717 - Error_mm, 4717 + Error_mm).ToString();
            string R3_Rand = random.Next(11885 - Error_mm, 11885 + Error_mm).ToString();
            R1_text.Text = R1_Rand;
            R2_text.Text = R2_Rand;
            R3_text.Text = R3_Rand;
           // button1_Click(sender,e);
            
           for(int i = 0; i < 5; i++)
            {
                TempXY = Stat_Pos();
                PositionXY[2 * i] = TempXY[0];
                PositionXY[(2 * i)+1] = TempXY[1];
            }
            for (int i = 0; i < 5; i++)
            {
                Final_POS_X += PositionXY[2 * i];
                Final_POS_Y += PositionXY[(2 * i) + 1];
            }
            Final_POS_X /= 5;
            Final_POS_Y /= 5;
            Final_POS_X = Math.Truncate(Final_POS_X);
            Final_POS_Y = Math.Truncate(Final_POS_Y);
            textBox1.Clear();
            textBox1.AppendText("(x,y) = (");
            textBox1.AppendText(Final_POS_X.ToString());
            textBox1.AppendText(",");
            textBox1.AppendText(Final_POS_Y.ToString());
            textBox1.AppendText(")\r");
            Wykres.Series["Pozycja"].Points.AddXY(Final_POS_X, Final_POS_Y);
            

        }

        public double[] Stat_Pos()
        
            {
                double x1, y1, r1, x2, y2, r2, x3, y3, r3;
                double[] D_Points = new double[4];
                double[] X_Points = new double[6];
                double[] Y_Points = new double[6];
                double[] X_Points_Calib = new double[6];
                double[] Y_Points_Calib = new double[6];
                int i = 0, ile = 0, Pop_wynik = 0;
                Random random = new Random();
                string R1_Rand = random.Next(4900, 5900).ToString();
                string R2_Rand = random.Next(4200, 5200).ToString();
                string R3_Rand = random.Next(11400, 12400).ToString();
                R1_text.Text = R1_Rand;
                R2_text.Text = R2_Rand;
                R3_text.Text = R3_Rand;
                x1 = Convert.ToDouble(X1_text.Text);
                y1 = Convert.ToDouble(Y1_text.Text);
                r1 = Convert.ToDouble(R1_text.Text);
                x2 = Convert.ToDouble(X2_text.Text);
                y2 = Convert.ToDouble(Y2_text.Text);
                r2 = Convert.ToDouble(R2_text.Text);
                x3 = Convert.ToDouble(X3_text.Text);
                y3 = Convert.ToDouble(Y3_text.Text);
                r3 = Convert.ToDouble(R3_text.Text);
                Wykres.Series["Kotwica"].Points.Clear();
                Wykres.Series["Obliczenia"].Points.Clear();
                //  Wykres.Series["Pozycja"].Points.Clear();
                Wykres.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
                Wykres.ChartAreas["ChartArea1"].AxisX.Maximum = 15000;
                Wykres.ChartAreas["ChartArea1"].AxisY.Minimum = -5000;
                Wykres.ChartAreas["ChartArea1"].AxisY.Maximum = 15000;
                Wykres.Series["Kotwica"].Points.AddXY(x1, y1);
                Wykres.Series["Kotwica"].Points.AddXY(x2, y2);
                Wykres.Series["Kotwica"].Points.AddXY(x3, y3);

              //  textBox1.AppendText("1->2");
                D_Points = Run_test(x1, y1, r1, x2, y2, r2);
                if (wynik == 1)
                {
                    X_Points[i] = D_Points[0];
                    Y_Points[i] = D_Points[1];
                    i++;
                    ile++;
                    Pop_wynik = wynik;
                }
                if (wynik == 2)
                {
                    X_Points[i] = D_Points[0];
                    Y_Points[i] = D_Points[1];
                    X_Points[i + 1] = D_Points[2];
                    Y_Points[i + 1] = D_Points[3];
                    i++;
                    ile += 2;
                    Pop_wynik = wynik;
                }
              //  textBox1.AppendText("2->3");
                D_Points = Run_test(x2, y2, r2, x3, y3, r3);
                if (wynik == 1)
                {
                    if (Pop_wynik == 2) i++;
                    X_Points[i] = D_Points[0];
                    Y_Points[i] = D_Points[1];
                    i++;
                    ile++;
                    Pop_wynik = wynik;
                }
                if (wynik == 2)
                {
                    if (Pop_wynik == 2) i++;
                    X_Points[i] = D_Points[0];
                    Y_Points[i] = D_Points[1];
                    X_Points[i + 1] = D_Points[2];
                    Y_Points[i + 1] = D_Points[3];
                    i++;
                    ile += 2;
                    Pop_wynik = wynik;
                }
              //  textBox1.AppendText("3->1");
                D_Points = Run_test(x1, y1, r1, x3, y3, r3);
                if (wynik == 1)
                {
                    if (Pop_wynik == 2) i++;
                    X_Points[i] = D_Points[0];
                    Y_Points[i] = D_Points[1];
                    i++;
                    ile++;
                }
                if (wynik == 2)
                {
                    if (Pop_wynik == 2) i++;
                    X_Points[i] = D_Points[0];
                    Y_Points[i] = D_Points[1];
                    X_Points[i + 1] = D_Points[2];
                    Y_Points[i + 1] = D_Points[3];
                    i++;
                    ile += 2;
                }
                double tmpX = 0, tmpY = 0;
                int ile_calib = Calibration(X_Points, Y_Points, X_Points_Calib, Y_Points_Calib, ile);
                for (int j = 0; j < ile_calib; j++)
                {
                    Wykres.Series["Obliczenia"].Points.AddXY(Math.Truncate(X_Points_Calib[j]), Math.Truncate(Y_Points_Calib[j]));
                    tmpX += X_Points_Calib[j];
                    tmpY += Y_Points_Calib[j];
                }
                double[] PositionXY = new double[2];
                PositionXY[0] = Math.Truncate(tmpX / ile_calib);
                PositionXY[1] = Math.Truncate(tmpY / ile_calib);

            return PositionXY;
            }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Connect_bt_Click(object sender, EventArgs e)
        {
            Receiving_text.Text += "Server starting";
            System.Net.IPAddress ip = System.Net.IPAddress.Parse(Host_TXT.Text);
            server.Start(ip, Convert.ToInt32(Port_TXT.Text));
        }

        private void Disconnect_bt_Click(object sender, EventArgs e)
        {
            if (server.IsStarted)
            {
                server.Stop();
                Receiving_text.Clear();
            }
        }

        private void Start_Measure_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            Interval_txt.Enabled = false;
            Interval_X_txt.Enabled = false;
            Interval_Y_txt.Enabled = false;
            X_CALIB.Enabled = false;
            Y_CALIB.Enabled = false;
            Error_Period.Enabled = false;
            Max_val_txt.Enabled = false;
            Avg_txt.Enabled = false;
          //  Thread Worker2 = new Thread(Pomiar);
           // Worker2.Start();
        }

        private void Stop_Measure_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Interval_txt.Enabled = true;
            Interval_X_txt.Enabled = true;
            Interval_Y_txt.Enabled = true;
            X_CALIB.Enabled = true;
            Y_CALIB.Enabled = true;
            Error_Period.Enabled = true;
            Max_val_txt.Enabled = true;
            Avg_txt.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            timer_clk++;
            if (ERROR == false)
            {
                int tmp;
                Int32.TryParse(Interval_txt.Text, out tmp);
                timer1.Interval = tmp;
                switch (clock)
                {
                    case 1: server.Broadcast("ok1"); break;
                    case 2: server.Broadcast("ok2"); break;
                    case 3: server.Broadcast("ok3"); break;
                }
                clock++;
                if (clock == 4)
                {
                    clock = 1;

                }
                ERROR = true;
                timer_clk = 0;
                if (Anchor_measurement.Checked == true)
                    clock = 0;
            }
            if (timer_clk * timer1.Interval >= Convert.ToInt32(Error_Period.Text))
            {
                ERROR = false;
                Reset_DWM(sender);
                // timer1.Interval = 500;
                timer_clk = 0;
            }
        }
        private void Pomiar()
        {
            double x1, y1, r1, x2, y2, r2, x3, y3, r3,intX,intY;
            double[] D_Points = new double[4];
            double[] X_Points = new double[6];
            double[] Y_Points = new double[6];
            double[] X_Points_Calib = new double[6];
            double[] Y_Points_Calib = new double[6];
            int i = 0, ile = 0, Pop_wynik = 0;
            x1 = Convert.ToDouble(X1_text.Text);
            y1 = Convert.ToDouble(Y1_text.Text);
            r1 = Convert.ToDouble(R1_text.Text) * 1000;
            x2 = Convert.ToDouble(X2_text.Text);
            y2 = Convert.ToDouble(Y2_text.Text);
            r2 = Convert.ToDouble(R2_text.Text) * 1000;
            x3 = Convert.ToDouble(X3_text.Text);
            y3 = Convert.ToDouble(Y3_text.Text);
            r3 = Convert.ToDouble(R3_text.Text) * 1000;
            intX = Convert.ToDouble(Interval_X_txt.Text);
            intY = Convert.ToDouble(Interval_Y_txt.Text);
            Wykres.Series["Kotwica"].Points.Clear();
            Wykres.Series["Obliczenia"].Points.Clear();
            //  Wykres.Series["Pozycja"].Points.Clear();
            Wykres.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
            Wykres.ChartAreas["ChartArea1"].AxisX.Maximum = x2;
            Wykres.ChartAreas["ChartArea1"].AxisY.Minimum = 0;
            Wykres.ChartAreas["ChartArea1"].AxisY.Maximum = y3;
            Wykres.ChartAreas["ChartArea1"].AxisX.Interval = intX;
            Wykres.ChartAreas["ChartArea1"].AxisY.Interval = intY;
            Wykres.Series["Kotwica"].Points.AddXY(x1, y1);
            Wykres.Series["Kotwica"].Points.AddXY(x2, y2);
            Wykres.Series["Kotwica"].Points.AddXY(x3, y3);

          //  textBox1.AppendText("1->2");
            D_Points = Run_test(x1, y1, r1, x2, y2, r2);
            if (wynik == 1)
            {
                X_Points[i] = D_Points[0];
                Y_Points[i] = D_Points[1];
                i++;
                ile++;
                Pop_wynik = wynik;
            }
            if (wynik == 2)
            {
                X_Points[i] = D_Points[0];
                Y_Points[i] = D_Points[1];
                X_Points[i + 1] = D_Points[2];
                Y_Points[i + 1] = D_Points[3];
                i++;
                ile += 2;
                Pop_wynik = wynik;
            }
          //  textBox1.AppendText("2->3");
            D_Points = Run_test(x2, y2, r2, x3, y3, r3);
            if (wynik == 1)
            {
                if (Pop_wynik == 2) i++;
                X_Points[i] = D_Points[0];
                Y_Points[i] = D_Points[1];
                i++;
                ile++;
                Pop_wynik = wynik;
            }
            if (wynik == 2)
            {
                if (Pop_wynik == 2) i++;
                X_Points[i] = D_Points[0];
                Y_Points[i] = D_Points[1];
                X_Points[i + 1] = D_Points[2];
                Y_Points[i + 1] = D_Points[3];
                i++;
                ile += 2;
                Pop_wynik = wynik;
            }
           // textBox1.AppendText("3->1");
            D_Points = Run_test( x3, y3, r3, x1, y1, r1);
            if (wynik == 1)
            {
                if (Pop_wynik == 2) i++;
                X_Points[i] = D_Points[0];
                Y_Points[i] = D_Points[1];
                i++;
                ile++;
            }
            if (wynik == 2)
            {
                if (Pop_wynik == 2) i++;
                X_Points[i] = D_Points[0];
                Y_Points[i] = D_Points[1];
                X_Points[i + 1] = D_Points[2];
                Y_Points[i + 1] = D_Points[3];
                i++;
                ile += 2;
            }
            double tmpX = 0, tmpY = 0;
            int ile_calib = Calibration(X_Points, Y_Points, X_Points_Calib, Y_Points_Calib, ile);
            for (int j = 0; j < ile_calib; j++)
            {
                Wykres.Series["Obliczenia"].Points.AddXY(Math.Truncate(X_Points_Calib[j]), Math.Truncate(Y_Points_Calib[j]));
                tmpX += X_Points_Calib[j];
                tmpY += Y_Points_Calib[j];
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(mydocpath, "Obliczenia_punkty.txt"), true))
                {
                    outputFile.WriteLine("punkt :X=" + X_Points_Calib[j].ToString()+" Y =" + Y_Points_Calib[j].ToString());
                }
            }

            double PositionX = Math.Truncate(tmpX / ile_calib);
            double PositionY = Math.Truncate(tmpY / ile_calib);
            int b;
            PosXY[0] = PositionX;
            PosXY[1] = PositionY;
            textBox1.Clear();
            textBox1.AppendText("(x,y) = (");
            textBox1.AppendText(PositionX.ToString());
            textBox1.AppendText(",");
            textBox1.AppendText(PositionY.ToString());

            textBox1.AppendText(")\r");
            if (Mov_std_avg.Checked == false)
            {
                int.TryParse(Avg_txt.Text, out b);
                a++;
                PositionX_avg += PositionX;
                PositionY_avg += PositionY;
                if (a == b)
                {
                    PositionX_avg /= b;
                    PositionY_avg /= b;
                    Wykres.Series["Pozycja"].Points.AddXY(PositionX_avg, PositionY_avg);
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(mydocpath, "Pozycja.txt"), true))
                    {
                        outputFile.WriteLine(PositionX_avg.ToString() + " " + PositionY_avg.ToString());
                    }
                    PositionX_avg = 0;
                    PositionY_avg = 0;
                    a = 0;

                }
            }
            else
            {
                int.TryParse(Avg_txt.Text, out b);
                if(first_avg == true)
                {
                    PositionX_mov_avg[3] = PositionX;
                    PositionY_mov_avg[3] = PositionY;
                }
                if (first_avg == false)
                {
                    PositionX_mov_avg[c] = PositionX;
                    PositionY_mov_avg[c] = PositionY;
                    c++;
                    if (c == 4)
                        first_avg = true;
                }
                if (first_avg == true)
                {
                    PositionX_avg = PositionX_mov_avg.Average() / b;
                    PositionY_avg = PositionY_mov_avg.Average() / b;
                    Wykres.Series["Pozycja"].Points.AddXY(PositionX_avg, PositionY_avg);
                    double tmp;
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(mydocpath, "Pozycja.txt"), true))
                    {
                        outputFile.WriteLine(PositionX_avg.ToString() + " " + PositionY_avg.ToString());
                    }
                    for (int j = 0; j < 2; j++)
                    {
                        tmp = PositionX_mov_avg[3 - j];
                        PositionX_mov_avg[2 - j] = tmp;
                        tmp = PositionY_mov_avg[3 - j];
                        PositionY_mov_avg[2 - j] = tmp;
                    }
                    PositionX_mov_avg[0] = 0;
                    PositionY_mov_avg[0] = 0;
                }
                
            }
        }
        

        private void Clear_Chart_Click(object sender, EventArgs e)
        {
            Wykres.Series["Pozycja"].Points.Clear();
        }
    }
}
