<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication4.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>Quiz</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.1/jquery.min.js"></script>
    <script>
        $(document).ready(function () {
            // ****************
            $('table thead tr').children(':eq(6)').css('display', 'none');
            $('table tbody tr').find('td:eq(6)').css('display', 'none');
            // ****************
            $("#mySwitch").click(function () {
                if ($(this).is(':checked')) {
                    var a = $('*').filter('.bg-white');
                    a.addClass('bg-dark');
                    a.removeClass('bg-white');

                    var b = $('*').filter('.text-dark');
                    b.addClass('text-white');
                    b.removeClass('text-dark');

                    var c = $('*').filter('.table-light');
                    c.addClass('table-dark');
                    c.removeClass('table-light');
                }
                else {
                    var a = $('*').filter('.bg-dark');
                    a.addClass('bg-white');
                    a.removeClass('bg-dark');

                    var b = $('*').filter('.text-white');
                    b.addClass('text-dark');
                    b.removeClass('text-white');

                    var c = $('*').filter('.table-dark');
                    c.addClass('table-light');
                    c.removeClass('table-dark');
                }
            });
            // ****************

            if ($("#nameh").text() != "") {
                $('#start').removeAttr('disabled');
            }

            $('#start').click(function () {
                $(this).attr('disabled', 'disabled');
                $('#finish').removeAttr('disabled');

                $('#panelq').fadeIn(1000);
                Disp(0);
            });

            var rowCount = $('table tbody tr').length;
            var count = 0;

            var falseA = 0;
            var trueA = 0;

            $('.next').click(function () {
                if (count == rowCount - 1)
                    return;

                count = count + 1;
                Display(count);
            });

            $('.prev').click(function () {
                if (count == 0)
                    return;

                count = count - 1;
                Disp(count);
            });

            $('#grade').click(function () {
                var n = count, i;
                var grade = 0;
                for (i = 0; i < n; i++) {
                    var x = $("#para").text();
                    console.log(x[i + 1])
                    if (x[i + 1] == $('table tbody tr:eq(' + Number(i) + ') td:eq(6)').text()) {
                        grade += 10;
                    }
                }
                $('#qnumber').text(grade);
            });

        });


        var grade = 0;
        function Disp(n) {

            $('#qnumber').text = n - 1;

            $('table tbody tr').removeClass('h2');
            $('table tbody tr:eq(' + Number(n) + ')').addClass('h2');
            $('.qtitle').text($('table tbody tr:eq(' + Number(n) + ') td:eq(1)').text());

            $('.qcontent').find('ul').children(':eq(0)').html('<input type="radio" class="form-check-input m-1" name="optradio" value="option1" id="o1" runat="server"><label id="l1" runat="server">' + $('table tbody tr:eq(' + Number(n) + ') td:eq(2)').text() + '</label>');
            $('.qcontent').find('ul').children(':eq(1)').html('<input type="radio" class="form-check-input m-1" name="optradio" value="option2" id="o2" runat="server"><label id="l2" runat="server">' + $('table tbody tr:eq(' + Number(n) + ') td:eq(3)').text() + '</label>');
            $('.qcontent').find('ul').children(':eq(2)').html('<input type="radio" class="form-check-input m-1" name="optradio" value="option3" id="o3" runat="server"><label id="l3" runat="server">' + $('table tbody tr:eq(' + Number(n) + ') td:eq(4)').text() + '</label>');
            $('.qcontent').find('ul').children(':eq(3)').html('<input type="radio" class="form-check-input m-1" name="optradio" value="option4" id="o4" runat="server"><label id="l4" runat="server">' + $('table tbody tr:eq(' + Number(n) + ') td:eq(5)').text() + '</label>');

            $('#progress').css('width', (n * 10) + '%')

        }

        function Display(n) {
            $('table tbody tr').removeClass('h2');
            $('table tbody tr:eq(' + Number(n) + ')').addClass('h2');
            $('#progress').css('width', (n * 10) + '%')
        }
    </script>
</head>
<body style="background: #999;">
    <form id="form1" runat="server">
        <main class="container">
            <header class="row mt-4">
                <div class="p-5 bg-dark text-white">
                    <div class="form-check form-switch">
                        <input class="form-check-input rounded-0" type="checkbox" id="mySwitch" name="darkmode" value="yes" checked />
                        <label class="form-check-label" for="mySwitch">Dark Mode</label>
                    </div>
                    <h1>Quiz</h1>
                    <p>Bootstrap 5 & Jquery</p>
                    <p>Your name:</p>
                    <asp:TextBox ID="Textname" runat="server"></asp:TextBox>
                    <asp:Button ID="submitbtn" runat="server" Text="submit" class="btn btn-primary rounded-0" OnClick="submitbtn_Click" />
                </div>
            </header>

            <section class="row mt-4">
                <section class="col-md-4  bg-dark">
                    <div class="card rounded-0 m-3 bg-dark text-white" style="width: 400px">
                        <img class="card-img-top rounded-0" src="images/img_avatar1.png" alt="Card image">
                        <div class="card-body rounded-0">
                            <h4 class="card-title" id="nameh" runat="server"></h4>
                            <p class="card-text">Master Student of Computer Engineering</p>
                            <button class="btn btn-primary rounded-0" type="button" style="width: 110px" data-bs-toggle="offcanvas" data-bs-target="#demo">
                                More ...
                            </button>
                            <button class="btn btn-primary rounded-0" id="start" type="button" style="width: 110px" disabled="disabled">
                               
                                Start Quiz
                            </button>
                            <button class="btn btn-primary rounded-0" id="finish" type="button" style="width: 110px" disabled="disabled" data-bs-toggle="modal" data-bs-target="#myModal">
                                Finish Quiz
                            </button>
                        </div>
                    </div>
                </section>
                <section class="col-md-8 bg-dark">

                    <div class="card rounded-0 m-3" id="panelq">
                        <div class="card-header h3 qtitle" id="qtitle" runat="server"></div>
                        <div class="card-body bg-dark text-white qcontent" style="height: 300px">
                            <ul class="list-group list-group-numbered list-group-flush h4">
                                <li class="list-group-item">
                                    <input type="radio" class="form-check-input m-1" name="optradio" value="option1" id="opti1" runat="server" />
                                    <label id="lab1" runat="server"></label>
                                </li>
                                <li class="list-group-item">
                                    <input type="radio" class="form-check-input m-1" name="optradio" value="option2" id="opti2" runat="server" />
                                    <label id="lab2" runat="server"></label>
                                </li>
                                <li class="list-group-item">
                                    <input type="radio" class="form-check-input m-1" name="optradio" value="option3" id="opti3" runat="server" />
                                    <label id="lab3" runat="server"></label>
                                </li>
                                <li class="list-group-item">
                                    <input type="radio" class="form-check-input m-1" name="optradio" value="option4" id="opti4" runat="server" />
                                    <label id="lab4" runat="server"></label>
                                </li>
                            </ul>
                            <p runat="server" id="qnumber" style="display:none;">1</p>
                        </div>
                        <div class="card-footer ">
                            <ul class="pagination justify-content-center" style="margin: 20px 0">
                                <!-- <li class="page-item prev">
                                    <a class=" page-link rounded-0 text-center" href="#" style="width: 100px;">Previous</a></li> -->

                                <!--  <li class="page-item next">
                                    <a class=" page-link rounded-0 text-center" href="#" style="width: 100px;">Next</a>  </li>-->

                                <asp:Button ID="previousbtn" runat="server" Text="Previous" class="prev" OnClick="prevbtn_click" />
                                <asp:Button ID="nextbtn" runat="server" Text="next" OnClick="nextbtn_click" class="next" />

                            </ul>

                        </div>

                        <div class="progress rounded-0" style="height: 30px">
                            <div id="progress" class="progress-bar progress-bar-striped progress-bar-animated" style="width: 0%"></div>
                        </div>
                    </div>
                </section>
            </section>

            <footer class="row mt-4">
                <div class="p-5 bg-dark text-white">
                    <div class="table-responsive">
                        <table class="table table-dark table-hover table-striped text-center">
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Question</th>
                                    <th>Option 1</th>
                                    <th>Option 2</th>
                                    <th>Option 3</th>
                                    <th>Option 4</th>
                                    <th>Answer</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>1</td>
                                    <td id="t11" runat="server">Q1</td>
                                    <td id="t12" runat="server">O1_1</td>
                                    <td id="t13" runat="server">O1_2</td>
                                    <td id="t14" runat="server">O1_3</td>
                                    <td id="t15" runat="server">O1_4</td>
                                    <td id="t16" runat="server">1</td>
                                </tr>
                                <tr>
                                    <td>2</td>
                                    <td id="t21" runat="server">Q2</td>
                                    <td id="t22" runat="server">O2_1</td>
                                    <td id="t23" runat="server">O2_2</td>
                                    <td id="t24" runat="server">O2_3</td>
                                    <td id="t25" runat="server">O2_4</td>
                                    <td id="t26" runat="server">3</td>
                                </tr>
                                <tr>
                                    <td>3</td>
                                    <td id="t31" runat="server">3</td>
                                    <td id="t32" runat="server">Q3</td>
                                    <td id="t33" runat="server">O3_1</td>
                                    <td id="t34" runat="server">O3_2</td>
                                    <td id="t35" runat="server">O3_3</td>
                                    <td id="t36" runat="server">O3_4</td>
                                </tr>
                                <tr>
                                    <td>4</td>
                                    <td id="t41" runat="server">1</td>
                                    <td id="t42" runat="server">Q4</td>
                                    <td id="t43" runat="server">O4_1</td>
                                    <td id="t44" runat="server">O4_2</td>
                                    <td id="t45" runat="server">O4_3</td>
                                    <td id="t46" runat="server">O4_4</td>
                                </tr>
                                <tr>
                                    <td>5</td>
                                    <td id="t51" runat="server">Q5</td>
                                    <td id="t52" runat="server">O5_1</td>
                                    <td id="t53" runat="server">O5_2</td>
                                    <td id="t54" runat="server">O5_3</td>
                                    <td id="t55" runat="server">O5_4</td>
                                    <td id="t56" runat="server">4</td>
                                </tr>
                                <tr>
                                    <td>6</td>
                                    <td id="t61" runat="server">Q6</td>
                                    <td id="t62" runat="server">O6_1</td>
                                    <td id="t63" runat="server">O6_2</td>
                                    <td id="t64" runat="server">O6_3</td>
                                    <td id="t65" runat="server">O6_4</td>
                                    <td id="t66" runat="server">2</td>
                                </tr>
                                <tr>
                                    <td>7</td>
                                    <td id="t71" runat="server">Q7</td>
                                    <td id="t72" runat="server">O7_1</td>
                                    <td id="t73" runat="server">O7_2</td>
                                    <td id="t74" runat="server">O7_3</td>
                                    <td id="t75" runat="server">O7_4</td>
                                    <td id="t76" runat="server">2</td>
                                </tr>
                                <tr>
                                    <td>8</td>
                                    <td id="t81" runat="server">Q8</td>
                                    <td id="t82" runat="server">O8_1</td>
                                    <td id="t83" runat="server">O8_2</td>
                                    <td id="t84" runat="server">O8_3</td>
                                    <td id="t85" runat="server">O8_4</td>
                                    <td id="t86" runat="server">2</td>
                                </tr>
                                <tr>
                                    <td>9</td>
                                    <td id="t91" runat="server">Q9</td>
                                    <td id="t92" runat="server">O9_1</td>
                                    <td id="t93" runat="server">O9_2</td>
                                    <td id="t94" runat="server">O9_3</td>
                                    <td id="t95" runat="server">O9_4</td>
                                    <td id="t96" runat="server">2</td>
                                </tr>
                                <tr>
                                    <td>10</td>
                                    <td id="t101" runat="server">Q10</td>
                                    <td id="t102" runat="server">O10_1</td>
                                    <td id="t103" runat="server">O10_2</td>
                                    <td id="t104" runat="server">O10_3</td>
                                    <td id="t105" runat="server">O10_4</td>
                                    <td id="t106" runat="server">1</td>
                                </tr>
                            </tbody>
                        </table>
                        <!-- this part must be visible only if the user is teacher -->
                        <textarea id="TextArea" cols="50" rows="2" runat="server"></textarea>
                        <br />
                        <asp:TextBox ID="opt1" runat="server"></asp:TextBox>
                        <asp:TextBox ID="opt2" runat="server"></asp:TextBox>
                        <asp:TextBox ID="opt3" runat="server"></asp:TextBox>
                        <asp:TextBox ID="opt4" runat="server"></asp:TextBox>
                        <br />
                        <asp:TextBox ID="ans" runat="server"></asp:TextBox>
                        <br />
                        <asp:Button ID="addbtn" runat="server" Text="addQ" class="btn btn-primary rounded-0" OnClick="addbtn_Click" />

                        <p class="mt-4">enter the question number:</p>
                        <asp:TextBox ID="num" runat="server"></asp:TextBox>
                        <asp:Button ID="editbtn" runat="server" Text="editQ" class="btn btn-primary rounded-0" OnClick="editbtn_Click" />
                        <br />
                        <div id="edit" runat="server">
                            <textarea id="TextArea1" cols="50" rows="2" runat="server"></textarea>
                            <br />
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                            <br />
                            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                            <br />
                            <asp:Button ID="donebtn" runat="server" Text="done" class="btn btn-primary rounded-0" OnClick="donebtn_Click" />
                        </div>
                    </div>
                </div>
            </footer>
            <!-- Offcanvas Sidebar -->
            <div class="offcanvas offcanvas-start" id="demo">
                <div class="offcanvas-header">
                    <h1 class="offcanvas-title">Heading</h1>
                    <button type="button" class="btn-close text-reset" data-bs-dismiss="offcanvas"></button>
                </div>
                <div class="offcanvas-body">
                    <p>Some text lorem ipsum.</p>
                    <p>Some text lorem ipsum.</p>
                    <button class="btn btn-secondary" type="button">A Button</button>
                </div>
            </div>

            <!-- The Modal -->
            <div class="modal " id="myModal">
                <div class="modal-dialog modal-dialog-centered ">
                    <div class="modal-content rounded-0">

                        <!-- Modal Header -->
                        <div class="modal-header">
                            <h4 class="modal-title">Resutls</h4>
                            <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                        </div>

                        <!-- Modal body -->
                        <div class="modal-body">
                            <label class="h3">True</label>
                            <div class="progress rounded-0" style="height: 30px">
                                <div class="progress-bar bg-success" style="width: 80%">80%</div>
                            </div>
                            <label class="h3">False</label>
                            <div class="progress rounded-0" style="height: 30px">

                                <div class="progress-bar  bg-danger" style="width: 20%">20%</div>
                            </div>
                        </div>

                        <!-- Modal footer -->
                        <div class="modal-footer">
                            <button type="button" class="btn btn-danger rounded-0" data-bs-dismiss="modal">Close</button>
                        </div>

                    </div>
                </div>
            </div>
        </main>
    </form>
</body>
</html>
