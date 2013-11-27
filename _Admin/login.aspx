﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="loja._Admin_login" %>

<!DOCTYPE html>

<html lang="pt-br">
<head>
    <meta charset="utf-8" />
    <title>Login Page - Ace Admin</title>
    <meta name="description" content="User login page" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <!--basic styles-->
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/css/bootstrap-responsive.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="assets/css/font-awesome.min.css" />

    <!--[if IE 7]>
    <link rel="stylesheet" href="assets/css/font-awesome-ie7.min.css" />
    <![endif]-->

    <!--page specific plugin styles-->

    <!--fonts-->
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Open+Sans:400,300" />

    <!--ace styles-->
    <link rel="stylesheet" href="assets/css/ace.min.css" />
    <link rel="stylesheet" href="assets/css/ace-responsive.min.css" />

    <!--[if lt IE 9]>
    <link rel="stylesheet" href="assets/css/ace-ie.min.css" />
    <![endif]-->
</head>

<body class="login-layout">
    <form id="form1" runat="server">
        <div class="container-fluid" id="main-container">
            <div id="main-content">
                <div class="row-fluid">
                    <div class="span12">
                        <div class="login-container">
                            <div class="row-fluid">
                                <div class="center">
                                    <h1><i class="icon-leaf green"></i> <span class="red">Ace</span> <span class="white">Application</span></h1>
                                    <h4 class="blue">&copy; Projeto E-Commerce</h4>
                                </div>
                            </div>
                            
                            <div class="space-6"></div>
                            <div class="row-fluid">
                                <div class="position-relative">
                                    <div id="login-box" class="visible widget-box no-border">
                                        <div class="widget-body">
                                            <div class="widget-main">
                                                <h4 class="header blue lighter bigger"><i class="icon-coffee green"></i> <%=Resources.login.Informacao%></h4>
                                                <div class="space-6"></div>
                                                <fieldset>
                                                    <label>
                                                        <span class="block input-icon input-icon-right">
                                                            <asp:TextBox ID="txtUsuario" runat="server" CssClass="span12"></asp:TextBox>
                                                            <i class="icon-user"></i>
                                                        </span>
                                                    </label>
                                                    
                                                    <label>
                                                        <span class="block input-icon input-icon-right">
                                                            <asp:TextBox ID="txtSenha" runat="server" CssClass="span12" TextMode="Password"></asp:TextBox>
                                                            <i class="icon-lock"></i>
                                                        </span>
                                                    </label>
                                                    
                                                    <div class="space"></div>
                                                    <div class="row-fluid">
                                                        <label class="span8">
                                                            <asp:CheckBox ID="chkLembrar" runat="server" />
                                                            <span class="lbl"> <%=Resources.login.Lembrar%></span>
                                                        </label>
                                                        
                                                        <button id="btnLogin" runat="server" class="span4 btn btn-small btn-primary" onserverclick="btnLogin_Click">
                                                            <i class="icon-key"></i>
                                                            <%=Resources.login.Entrar%>
                                                        </button>
                                                    </div>
                                                </fieldset>
                                            </div><!--/widget-main-->
                                        </div><!--/widget-body-->
                                    </div><!--/login-box-->
                                    
                                    <div id="forgot-box" class="widget-box no-border">
                                        <div class="widget-body">
                                            <div class="widget-main">
                                                <h4 class="header red lighter bigger">
                                                    <i class="icon-key"></i>
                                                    Retrieve Password
                                                </h4>
                                                
                                                <div class="space-6"></div>
                                                <p>Enter your email and to receive instructions</p>
                                                
                                                <fieldset>
                                                    <label>
                                                        <span class="block input-icon input-icon-right">
                                                            <input type="email" class="span12" placeholder="Email" />
                                                            <i class="icon-envelope"></i>
                                                        </span>
                                                    </label>
                                                    
                                                    <div class="row-fluid">
                                                        <button onclick="return false;" class="span5 offset7 btn btn-small btn-danger">
                                                            <i class="icon-lightbulb"></i> Send Me!
                                                        </button>
                                                    </div>
                                                </fieldset>
                                            </div><!--/widget-main-->
                                            
                                            <div class="toolbar center">
                                                <a href="#" onclick="show_box('login-box'); return false;" class="back-to-login-link">
                                                    Back to login
                                                    <i class="icon-arrow-right"></i>
                                                </a>
                                            </div>
                                        </div><!--/widget-body-->
                                    </div><!--/forgot-box-->
                                    
                                    <div id="signup-box" class="widget-box no-border">
                                        <div class="widget-body">
                                            <div class="widget-main">
                                                <h4 class="header green lighter bigger">
                                                    <i class="icon-group blue"></i>
                                                    New User Registration
                                                </h4>
                                                
                                                <div class="space-6"></div>
                                                <p>Enter your details to begin:</p>
                                                
                                                <fieldset>
                                                    <label>
                                                        <span class="block input-icon input-icon-right">
                                                            <input type="email" class="span12" placeholder="Email" />
                                                            <i class="icon-envelope"></i>
                                                        </span>
                                                    </label>
                                                    
                                                    <label>
                                                        <span class="block input-icon input-icon-right">
                                                            <input type="text" class="span12" placeholder="Username" />
                                                            <i class="icon-user"></i>
                                                        </span>
                                                    </label>
                                                    
                                                    <label>
                                                        <span class="block input-icon input-icon-right">
                                                            <input type="password" class="span12" placeholder="Password" />
                                                            <i class="icon-lock"></i>
                                                        </span>
                                                    </label>
                                                    
                                                    <label>
                                                        <span class="block input-icon input-icon-right">
                                                            <input type="password" class="span12" placeholder="Repeat password" />
                                                            <i class="icon-retweet"></i>
                                                        </span>
                                                    </label>
                                                    
                                                    <label>
                                                        <input type="checkbox" />
                                                        <span class="lbl">
                                                            I accept the
                                                            <a href="#">User Agreement</a>
                                                        </span>
                                                    </label>
                                                    
                                                    <div class="space-24"></div>
                                                    <div class="row-fluid">
                                                        <button type="reset" class="span6 btn btn-small">
                                                            <i class="icon-refresh"></i>
                                                            Reset
                                                        </button>
                                                        
                                                        <button onclick="return false;" class="span6 btn btn-small btn-success">
                                                            Register
                                                            <i class="icon-arrow-right icon-on-right"></i>
                                                        </button>
                                                    </div>
                                                </fieldset>
                                            </div>
                                            
                                            <div class="toolbar center">
                                                <a href="#" onclick="show_box('login-box'); return false;" class="back-to-login-link">
                                                    <i class="icon-arrow-left"></i>
                                                    Back to login
                                                </a>
                                            </div>
                                        </div><!--/widget-body-->
                                    </div><!--/signup-box-->
                                </div><!--/position-relative-->
                            </div>
                        </div>
                    </div><!--/span-->
                </div><!--/row-->
            </div>
        </div><!--/.fluid-container-->
        
        <!--basic scripts-->
        <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
        <script type="text/javascript">
            window.jQuery || document.write("<script src='assets/js/jquery-1.9.1.min.js'>" + "<" + "/script>");
        </script>
        
        <!--page specific plugin scripts-->
        
        <!--inline scripts related to this page-->
        <script type="text/javascript">
            function show_box(id) {
                $('.widget-box.visible').removeClass('visible');
                $('#' + id).addClass('visible');
            }
        </script>
    </form>
</body>

</html>