using System;
using System.Data.SqlClient;

namespace WebApplication4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        static int sid;
        string connectionS = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=MyProject;Integrated Security=True;Pooling=False";
        int count = 1;
        public int idEdit, number;
        public static object Document { get; private set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            edit.Visible = false;

            string queryS = "select * from Questions";
            int paramValue = 1;
            using (SqlConnection con = new SqlConnection(connectionS))
            {
                SqlCommand command = new SqlCommand(queryS, con);
                command.Parameters.AddWithValue("@pricePoint", paramValue);

                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        switch (count)
                        {
                            case 1:
                                t11.InnerText = reader.GetString(1);
                                t12.InnerText = reader.GetString(2);
                                t13.InnerText = reader.GetString(3);
                                t14.InnerText = reader.GetString(4);
                                t15.InnerText = reader.GetString(5);
                                t16.InnerText = reader.GetInt32(6).ToString();
                                break;
                            case 2:
                                t21.InnerText = reader.GetString(1);
                                t22.InnerText = reader.GetString(2);
                                t23.InnerText = reader.GetString(3);
                                t24.InnerText = reader.GetString(4);
                                t25.InnerText = reader.GetString(5);
                                t26.InnerText = reader.GetInt32(6).ToString();
                                break;
                            case 3:
                                t31.InnerText = reader.GetString(1);
                                t32.InnerText = reader.GetString(2);
                                t33.InnerText = reader.GetString(3);
                                t34.InnerText = reader.GetString(4);
                                t35.InnerText = reader.GetString(5);
                                t36.InnerText = reader.GetInt32(6).ToString();
                                break;
                            case 4:
                                t41.InnerText = reader.GetString(1);
                                t42.InnerText = reader.GetString(2);
                                t43.InnerText = reader.GetString(3);
                                t44.InnerText = reader.GetString(4);
                                t45.InnerText = reader.GetString(5);
                                t46.InnerText = reader.GetInt32(6).ToString();
                                break;
                            case 5:
                                t51.InnerText = reader.GetString(1);
                                t52.InnerText = reader.GetString(2);
                                t53.InnerText = reader.GetString(3);
                                t54.InnerText = reader.GetString(4);
                                t55.InnerText = reader.GetString(5);
                                t56.InnerText = reader.GetInt32(6).ToString();
                                break;
                            case 6:
                                t61.InnerText = reader.GetString(1);
                                t62.InnerText = reader.GetString(2);
                                t63.InnerText = reader.GetString(3);
                                t64.InnerText = reader.GetString(4);
                                t65.InnerText = reader.GetString(5);
                                t66.InnerText = reader.GetInt32(6).ToString();
                                break;
                            case 7:
                                t71.InnerText = reader.GetString(1);
                                t72.InnerText = reader.GetString(2);
                                t73.InnerText = reader.GetString(3);
                                t74.InnerText = reader.GetString(4);
                                t75.InnerText = reader.GetString(5);
                                t76.InnerText = reader.GetInt32(6).ToString();
                                break;
                            case 8:
                                t81.InnerText = reader.GetString(1);
                                t82.InnerText = reader.GetString(2);
                                t83.InnerText = reader.GetString(3);
                                t84.InnerText = reader.GetString(4);
                                t85.InnerText = reader.GetString(5);
                                t86.InnerText = reader.GetInt32(6).ToString();
                                break;
                            case 9:
                                t91.InnerText = reader.GetString(1);
                                t92.InnerText = reader.GetString(2);
                                t93.InnerText = reader.GetString(3);
                                t94.InnerText = reader.GetString(4);
                                t95.InnerText = reader.GetString(5);
                                t96.InnerText = reader.GetInt32(6).ToString();
                                break;
                            case 10:
                                t101.InnerText = reader.GetString(1);
                                t102.InnerText = reader.GetString(2);
                                t103.InnerText = reader.GetString(3);
                                t104.InnerText = reader.GetString(4);
                                t105.InnerText = reader.GetString(5);
                                t106.InnerText = reader.GetInt32(6).ToString();
                                break;
                        }
                        count++;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        public void submitbtn_Click(object sender, EventArgs e)
        {
            string connectionS = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=MyProject;Integrated Security=True;Pooling=False";
            string name = Textname.Text;
            Textname.Text = "";
            nameh.InnerText = name;

            int paramValue = count;
            int y = 0;
            string queryS = "select count(*) from students where name ='" + name + "'";
            using (SqlConnection con = new SqlConnection(connectionS))
            {
                SqlCommand command = new SqlCommand(queryS, con);
                command.Parameters.AddWithValue("@pricePoint", paramValue);

                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        y = reader.GetInt32(0);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            if (y == 0)
            {
                SqlConnection con = new SqlConnection(connectionS);
                try
                {
                    string Command = "insert into Students values('" + name + "');";
                    SqlCommand cm = new SqlCommand(Command, con);
                    con.Open();
                    cm.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            queryS = "select id from students where name ='" + name + "'";
            using (SqlConnection con = new SqlConnection(connectionS))
            {
                SqlCommand command = new SqlCommand(queryS, con);
                command.Parameters.AddWithValue("@pricePoint", paramValue);

                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        sid = reader.GetInt32(0);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);


                }
            }
        }

        protected void addbtn_Click(object sender, EventArgs e)
        {
            int sw = 1;
            string text = TextArea.InnerText;
            string op1 = opt1.Text;
            string op2 = opt2.Text;
            string op3 = opt3.Text;
            string op4 = opt4.Text;
            string an = ans.Text;
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(op1) || string.IsNullOrEmpty(op2)
                || string.IsNullOrEmpty(op3) || string.IsNullOrEmpty(op4) || string.IsNullOrEmpty(an))
            {
                sw = 0;
            }
            if (sw == 1)
            {
                TextArea.InnerText = "";
                opt1.Text = "";
                opt2.Text = "";
                opt3.Text = "";
                opt4.Text = "";
                ans.Text = "";

                //adding to database
                SqlConnection con = new SqlConnection(connectionS);
                try
                {
                    string Command = "insert into Questions values('" + text + "','" + op1 + "','" + op2 + "','" + op3 + "','" + op4 + "','" + an + "');";
                    SqlCommand cm = new SqlCommand(Command, con);
                    con.Open();
                    cm.ExecuteNonQuery();

                }
                catch
                {

                }
                finally
                {
                    con.Close();
                }

                //showing in table
                switch (count)
                {
                    case 1:
                        t11.InnerText = text;
                        t12.InnerText = op1;
                        t13.InnerText = op2;
                        t14.InnerText = op3;
                        t15.InnerText = op4;
                        t16.InnerText = an;
                        break;
                    case 2:
                        t21.InnerText = text;
                        t22.InnerText = op1;
                        t23.InnerText = op2;
                        t24.InnerText = op3;
                        t25.InnerText = op4;
                        t26.InnerText = an;
                        break;
                    case 3:
                        t31.InnerText = text;
                        t32.InnerText = op1;
                        t33.InnerText = op2;
                        t34.InnerText = op3;
                        t35.InnerText = op4;
                        t36.InnerText = an;
                        break;
                    case 4:
                        t41.InnerText = text;
                        t42.InnerText = op1;
                        t43.InnerText = op2;
                        t44.InnerText = op3;
                        t45.InnerText = op4;
                        t46.InnerText = an;
                        break;
                    case 5:
                        t51.InnerText = text;
                        t52.InnerText = op1;
                        t53.InnerText = op2;
                        t54.InnerText = op3;
                        t55.InnerText = op4;
                        t56.InnerText = an;
                        break;
                    case 6:
                        t61.InnerText = text;
                        t62.InnerText = op1;
                        t63.InnerText = op2;
                        t64.InnerText = op3;
                        t65.InnerText = op4;
                        t66.InnerText = an;
                        break;
                    case 7:
                        t71.InnerText = text;
                        t72.InnerText = op1;
                        t73.InnerText = op2;
                        t74.InnerText = op3;
                        t75.InnerText = op4;
                        t76.InnerText = an;
                        break;
                    case 8:
                        t81.InnerText = text;
                        t82.InnerText = op1;
                        t83.InnerText = op2;
                        t84.InnerText = op3;
                        t85.InnerText = op4;
                        t86.InnerText = an;
                        break;
                    case 9:
                        t91.InnerText = text;
                        t92.InnerText = op1;
                        t93.InnerText = op2;
                        t94.InnerText = op3;
                        t95.InnerText = op4;
                        t96.InnerText = an;
                        break;
                    case 10:
                        t101.InnerText = text;
                        t102.InnerText = op1;
                        t103.InnerText = op2;
                        t104.InnerText = op3;
                        t105.InnerText = op4;
                        t106.InnerText = an;
                        break;
                }
                count++;
            }
        }

        protected void editbtn_Click(object sender, EventArgs e)
        {
            edit.Visible = true;
            number = Int32.Parse(num.Text);
            int count2 = 1;

            string queryS = "select * from Questions";
            int paramValue = count;
            using (SqlConnection con = new SqlConnection(connectionS))
            {
                SqlCommand command = new SqlCommand(queryS, con);
                command.Parameters.AddWithValue("@pricePoint", paramValue);

                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (count2 == number)
                        {
                            idEdit = reader.GetInt32(0);

                            TextArea1.InnerText = reader.GetString(1);
                            TextBox1.Text = reader.GetString(2);
                            TextBox2.Text = reader.GetString(3);
                            TextBox3.Text = reader.GetString(4);
                            TextBox4.Text = reader.GetString(5);
                            TextBox5.Text = reader.GetInt32(6).ToString();
                            break;
                        }
                        count2++;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        protected void donebtn_Click(object sender, EventArgs e)
        {
            string text = TextArea1.InnerText;
            string op1 = TextBox1.Text;
            string op2 = TextBox2.Text;
            string op3 = TextBox3.Text;
            string op4 = TextBox4.Text;
            string an = TextBox5.Text;

            number = Int32.Parse(num.Text);
            int count2 = 1;

            string queryS = "select * from Questions";
            int paramValue = count;
            using (SqlConnection conn = new SqlConnection(connectionS))
            {
                SqlCommand command = new SqlCommand(queryS, conn);
                command.Parameters.AddWithValue("@pricePoint", paramValue);

                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (count2 == number)
                        {
                            idEdit = reader.GetInt32(0);
                            break;
                        }
                        count2++;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }


                //adding to database
                SqlConnection conn2 = new SqlConnection(connectionS);
                try
                {
                    string Command = "update Questions " +
                        "Set text='" + text + "', opt1='" + op1 + "',opt2='" + op2 + "',opt3='" + op3 + "',opt4='" + op4 + "',ans='" + an + "'" +
                        "where Id='" + idEdit + "';";
                    SqlCommand cm = new SqlCommand(Command, conn2);
                    conn2.Open();
                    cm.ExecuteNonQuery();
                }
                catch
                {

                }
                finally
                {
                    conn2.Close();
                }

                //showing in table
                switch (number)
                {
                    case 1:
                        t11.InnerText = text;
                        t12.InnerText = op1;
                        t13.InnerText = op2;
                        t14.InnerText = op3;
                        t15.InnerText = op4;
                        t16.InnerText = an;
                        break;
                    case 2:
                        t21.InnerText = text;
                        t22.InnerText = op1;
                        t23.InnerText = op2;
                        t24.InnerText = op3;
                        t25.InnerText = op4;
                        t26.InnerText = an;
                        break;
                    case 3:
                        t31.InnerText = text;
                        t32.InnerText = op1;
                        t33.InnerText = op2;
                        t34.InnerText = op3;
                        t35.InnerText = op4;
                        t36.InnerText = an;
                        break;
                    case 4:
                        t41.InnerText = text;
                        t42.InnerText = op1;
                        t43.InnerText = op2;
                        t44.InnerText = op3;
                        t45.InnerText = op4;
                        t46.InnerText = an;
                        break;
                    case 5:
                        t51.InnerText = text;
                        t52.InnerText = op1;
                        t53.InnerText = op2;
                        t54.InnerText = op3;
                        t55.InnerText = op4;
                        t56.InnerText = an;
                        break;
                    case 6:
                        t61.InnerText = text;
                        t62.InnerText = op1;
                        t63.InnerText = op2;
                        t64.InnerText = op3;
                        t65.InnerText = op4;
                        t66.InnerText = an;
                        break;
                    case 7:
                        t71.InnerText = text;
                        t72.InnerText = op1;
                        t73.InnerText = op2;
                        t74.InnerText = op3;
                        t75.InnerText = op4;
                        t76.InnerText = an;
                        break;
                    case 8:
                        t81.InnerText = text;
                        t82.InnerText = op1;
                        t83.InnerText = op2;
                        t84.InnerText = op3;
                        t85.InnerText = op4;
                        t86.InnerText = an;
                        break;
                    case 9:
                        t91.InnerText = text;
                        t92.InnerText = op1;
                        t93.InnerText = op2;
                        t94.InnerText = op3;
                        t95.InnerText = op4;
                        t96.InnerText = an;
                        break;
                    case 10:
                        t101.InnerText = text;
                        t102.InnerText = op1;
                        t103.InnerText = op2;
                        t104.InnerText = op3;
                        t105.InnerText = op4;
                        t106.InnerText = an;
                        break;
                }

                edit.Visible = false;
                num.Text = "";

            }

        }


        int[] answered = new int[10];
        int[] grades = new int[10];
        protected void nextbtn_click(object sender, EventArgs e)
        {
            int answer = 0;
            if (opti1.Checked)
            {
                answer = 1;
                opti1.Checked = false;
            }
            else if (opti2.Checked)
            {
                answer = 2;
                opti2.Checked = false;
            }
            else if (opti3.Checked)
            {
                answer = 3;
                opti3.Checked = false;
            }
            else if (opti4.Checked)
            {
                answer = 4;
                opti4.Checked = false;
            }

            number = Int32.Parse(qnumber.InnerText);
            qnumber.InnerText = (number + 1).ToString();
            int correctans = 0;
            answered[number - 1] = answer;

            int qid = 0, qidn = 0, userid = sid;

            int count2 = 1;
            string queryS = "select * from Questions";
            int paramValue = count;
            using (SqlConnection con = new SqlConnection(connectionS))
            {
                SqlCommand command = new SqlCommand(queryS, con);
                command.Parameters.AddWithValue("@pricePoint", paramValue);

                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (count2 == number)
                        {
                            correctans = reader.GetInt32(6);
                            qid = reader.GetInt32(0);
                        }
                        else if (count2 == number + 1)
                        {
                            qidn = reader.GetInt32(0);
                            qtitle.InnerText = reader.GetString(1);
                            lab1.InnerText = reader.GetString(2);
                            lab2.InnerText = reader.GetString(3);
                            lab3.InnerText = reader.GetString(4);
                            lab4.InnerText = reader.GetString(5);
                            break;
                        }
                        count2++;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                /* if(correctans == answer)
                 {
                     grades[number-1] = 10;
                 }

                 if (answered[number] != 0)
                 {
                     if (answered[number] == 1)
                     {
                         opti1.Checked = true;
                     }else if (answered[number] == 2)
                     {
                         opti2.Checked = true;
                     }else if(answered[number] == 3)
                     {
                         opti3.Checked = true;
                     }else if(answered[number] == 4)
                     {
                         opti4.Checked = true;
                     }
                 }*/


            }
            int y = 0;
            queryS = "select count(*) from answers where qid ='" + qid + "'and userid ='" + userid + "'";
            using (SqlConnection con = new SqlConnection(connectionS))
            {
                SqlCommand command = new SqlCommand(queryS, con);
                command.Parameters.AddWithValue("@pricePoint", paramValue);

                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        y = reader.GetInt32(0);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            if (y > 0)
            {
                SqlConnection conn = new SqlConnection(connectionS);
                try
                {
                    string Command = "update answers set ans = '" + answer + "'where qid='" + qid + "'and userid ='" + userid + "'";
                    SqlCommand cm = new SqlCommand(Command, conn);
                    conn.Open();
                    cm.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {

                SqlConnection conn = new SqlConnection(connectionS);
                try
                {
                    string Command = "insert into answers values('" + qid + "','" + userid + "','" + answer + "');";
                    SqlCommand cm = new SqlCommand(Command, conn);
                    conn.Open();
                    cm.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }


            int x = 0;
            queryS = "select ans from answers where qid ='" + qidn + "'and userid ='" + userid + "'";
            using (SqlConnection con = new SqlConnection(connectionS))
            {
                SqlCommand command = new SqlCommand(queryS, con);
                command.Parameters.AddWithValue("@pricePoint", paramValue);

                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        x = reader.GetInt32(0);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if (x == 1)
            {
                opti1.Checked = true;
            }
            else if (x == 2)
            {
                opti2.Checked = true;
            }
            else if (x == 3)
            {
                opti3.Checked = true;
            }
            else if (x == 4)
            {
                opti4.Checked = true;
            }
        }

        protected void prevbtn_click(object sender, EventArgs e)
        {
            int answer = 0, qid = 0, qidp = 0, userid = sid;
            if (opti1.Checked)
            {
                answer = 1;
                opti1.Checked = false;
            }
            else if (opti2.Checked)
            {
                answer = 2;
                opti2.Checked = false;
            }
            else if (opti3.Checked)
            {
                answer = 3;
                opti3.Checked = false;
            }
            else if (opti4.Checked)
            {
                answer = 4;
                opti4.Checked = false;
            }

            number = Int32.Parse(qnumber.InnerText);
            qnumber.InnerText = (number - 1).ToString();
            int correctans = 0;
            answered[number - 1] = answer;

            int count2 = 1;
            string queryS = "select * from Questions";
            int paramValue = count;
            using (SqlConnection con = new SqlConnection(connectionS))
            {
                SqlCommand command = new SqlCommand(queryS, con);
                command.Parameters.AddWithValue("@pricePoint", paramValue);

                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (count2 == number)
                        {
                            correctans = reader.GetInt32(6);
                            qid = reader.GetInt32(0);
                        }
                        else if (count2 == number - 1)
                        {
                            qidp = reader.GetInt32(0);
                            qtitle.InnerText = reader.GetString(1);
                            lab1.InnerText = reader.GetString(2);
                            lab2.InnerText = reader.GetString(3);
                            lab3.InnerText = reader.GetString(4);
                            lab4.InnerText = reader.GetString(5);
                            break;
                        }
                        count2++;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                if (correctans == answer)
                {
                    grades[number - 1] = 10;
                }

                if (answered[number] != 0)
                {
                    if (answered[number] == 1)
                    {
                        opti1.Checked = true;
                    }
                    else if (answered[number] == 2)
                    {
                        opti2.Checked = true;
                    }
                    else if (answered[number] == 3)
                    {
                        opti3.Checked = true;
                    }
                    else if (answered[number] == 4)
                    {
                        opti4.Checked = true;
                    }
                }
            }

            int y = 0;
            queryS = "select count(*) from answers where qid ='" + qid + "'and userid ='" + userid + "'";
            using (SqlConnection con = new SqlConnection(connectionS))
            {
                SqlCommand command = new SqlCommand(queryS, con);
                command.Parameters.AddWithValue("@pricePoint", paramValue);

                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        y = reader.GetInt32(0);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            if (y > 0)
            {
                SqlConnection conn = new SqlConnection(connectionS);
                try
                {
                    string Command = "update answers set ans = '" + answer + "'where qid='" + qid + "'and userid ='" + userid + "'";
                    SqlCommand cm = new SqlCommand(Command, conn);
                    conn.Open();
                    cm.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {

                SqlConnection conn = new SqlConnection(connectionS);
                try
                {
                    string Command = "insert into answers values('" + qid + "','" + userid + "','" + answer + "');";
                    SqlCommand cm = new SqlCommand(Command, conn);
                    conn.Open();
                    cm.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }


            int x = 0;
            queryS = "select ans from answers where qid ='" + qidp + "'";
            using (SqlConnection con = new SqlConnection(connectionS))
            {
                SqlCommand command = new SqlCommand(queryS, con);
                command.Parameters.AddWithValue("@pricePoint", paramValue);

                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        x = reader.GetInt32(0);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if (x == 1)
            {
                opti1.Checked = true;
            }
            else if (x == 2)
            {
                opti2.Checked = true;
            }
            else if (x == 3)
            {
                opti3.Checked = true;
            }
            else if (x == 4)
            {
                opti4.Checked = true;
            }
        }
    }
}