<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm8.aspx.cs" Inherits="WebApplication1.MainSystem.WebForm8" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<head>
   <title>Bootstrap 实例 - 折叠面板</title>
    <link href="bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="jquery.min.js" type="text/javascript"></script>
    <script src="bootstrap.min.js" type="text/javascript"></script>
</head>
<body>

<div class="panel-group" id="accordion">
  <div class="panel panel-default">
    <div class="panel-heading">
      <h4 class="panel-title">
        <a data-toggle="collapse" data-parent="#accordion" 
          href="#collapseOne">
          点击我进行展开，再次点击我进行折叠。第 1 部分
        </a>
      </h4>
    </div>
    <div id="collapseOne" class="panel-collapse collapse in">
      <div class="panel-body">
        Nihil anim keffiyeh helvetica, craft beer labore wes anderson 
        cred nesciunt sapiente ea proident. Ad vegan excepteur butcher 
        vice lomo.
      </div>
    </div>
  </div>
  <div class="panel panel-default">
    <div class="panel-heading">
      <h4 class="panel-title">
        <a data-toggle="collapse" data-parent="#accordion" 
          href="#collapseTwo">
          点击我进行展开，再次点击我进行折叠。第 2 部分
        </a>
      </h4>
    </div>
    <div id="collapseTwo" class="panel-collapse collapse">
      <div class="panel-body">
        Nihil anim keffiyeh helvetica, craft beer labore wes anderson 
        cred nesciunt sapiente ea proident. Ad vegan excepteur butcher 
        vice lomo.
      </div>
    </div>
  </div>
  <div class="panel panel-default">
    <div class="panel-heading">
      <h4 class="panel-title">
        <a data-toggle="collapse" data-parent="#accordion" 
          href="#collapseThree">
          点击我进行展开，再次点击我进行折叠。第 3 部分
        </a>
      </h4>
    </div>
    <div id="collapseThree" class="panel-collapse collapse">
      <div class="panel-body">
        Nihil anim keffiyeh helvetica, craft beer labore wes anderson 
        cred nesciunt sapiente ea proident. Ad vegan excepteur butcher 
        vice lomo.
      </div>
    </div>
  </div>
</div>

</body>
</html>
