	
//jianli_index 为是 简历输入的计数器
//old_index 简历  输入的计数器  用于删除简历
//  lu_focus焦点 计数器 用于文本框赋值
// leixing 学生类型 计数器

  	    var jianli_index =0;
    	var old_index=0;
    	var leixing="0";
    	var lu_focus;
    	var cailiao_checked;
	    var cailiaoObj;
	    var cailiaoObjValue;
	    var cailiao_tanchu;
	
	 // 鉴定 设置
        function  JiandingSetVal()
        {
        var strjianding="";
        var cbl_jiedao= $("#CheckBoxList_jianding :checkbox:checked" );
        if(cbl_jiedao .length==0)
        {
        alert ("请至少选择一项");
        return  false ;

        }
        else {
       $("#CheckBoxList_jianding :checkbox:checked" ).next().each(function(){
        if($(this ).html().substring(3,$(this ).html().length)=="其他")
        {
        var strneirong=$("#TextBox_qitajianding").val();
        strjianding +=strneirong+" ";
        }
        else 
        {
        strjianding +=$(this ).html().substring(3,$(this ).html().length)+" ";
        }
        });
        $("#tb_jianding").val(strjianding);
        return true ;
       }
         }
  
    //鉴定 筛选  ddl 和tb 
      function JiandingSaixuan()
    	{
    	var rdID="CheckBoxList_jianding";
    	var ddlID="DropDownList_jiandingFZ";
    	var tbID="textbox_jiandingCX";
        var  text2="";
    	var ddl1= document.getElementById(ddlID);
    	var text=ddl1.options[ddl1.selectedIndex].text;
    	var minstr=text.substring(0,2);
    	var maxstr=text .substring(3,5);
    	
    	var textbox=document.getElementById(tbID);
        var text1=	textbox.value;
    	var rb2=document.getElementById(rdID);
    	var rbi=rb2.getElementsByTagName("input");
    	var rbl=rb2.getElementsByTagName("LABEL");
    	var rbtd=rb2.getElementsByTagName("TD");
    	for (var i=0; i<rbi .length;i++)
    	{
    	
    	 var str=  rbl[i].innerText;
         var b= str.substring(0,2);
    	 var j = str.indexOf(text1,0);

    	     if(minstr<=b&&b<=maxstr&&j>=0 )
    	     {
    	     rbi[i].style.display="";
    	     rbl[i].style.display="";
    	     
    	     }
    	     else 
    	     {
    	     rbi[i].style.display="none";
    	     rbl[i].style.display="none";
    	     
    	     }
    	 }
 	
    	}

    	function saixuanbyddl()
    	{
    	var rdID=$("#rdl_lu_Id").val();
    	var ddlID="ddl_fenzu";
    	var tbID="textbox3";
        var  text2="";
    	var ddl1= document.getElementById(ddlID);
    	var text=ddl1.options[ddl1.selectedIndex].text;
    	var minstr=text.substring(0,2);
    	var maxstr=text .substring(3,5);
    	
    	var textbox=document.getElementById(tbID);
        var text1=	textbox.value;
    	var rb2=document.getElementById(rdID);
    	var rbi=rb2.getElementsByTagName("input");
    	var rbl=rb2.getElementsByTagName("LABEL");
    	var rbtd=rb2.getElementsByTagName("TD");
    	for (var i=0; i<rbi .length;i++)
    	{
    	 var str=  rbl[i].innerText;
         var b= str.substring(0,2);
    	 var j = str.indexOf(text1,0);
    	     if(minstr<=b&&b<=maxstr&&j>=0 )
    	     {
    	     rbtd[i].style.display="";
    	     }
    	     else 
    	     {
    	      rbtd[i].style.display="none";
    	     }
    	 }
 	
    	}
    	//设置值  radiobuttonlist2选择到的值赋值给 textbox 控件
    	function setValue()
    	{
        var rdID="#"+$("#rdl_lu_Id").val()+" input:checked+label";
       var rdid1= $(rdID);
        if( rdid1.length==0)
        {
        alert ("请选择一个路段");
        return false ;
        }
        var str=   $(rdID).html();
         var jint1=str.indexOf("其他",0)
        if(jint1 >0)
        {
        
    	//var str= $("#RadioButtonList2 input:checked+label").html();
         str=str.substring(0,2)+"."+$("#tb_qita").val();
        }

        lu_focus.val(str);
        if(lu_focus .attr("id")=="tb_zhuzhilu")
        {
         $("#hd_zhuzhi1").val(str.substring(0,2));
         $("#Label_zhuzhi1").text(str.substring(0,2));
        }
        else if(lu_focus .attr("id")=="tb_jianhu2lu")
        {
         $("#hd_zhuzhi2").val(str.substring(0,2));
         $("#Label_zhuzhi2").text(str.substring(0,2));
        }
        var  d= lu_focus.parent().next();
        d.find("input").focus();
        return  true ;
    	}

    	$(function() {
    	    $('#RadioButtonList_jianding input').click(function() {
    	        if ($(this).val() == "0") {
    	            $("#CheckBoxList_jianding :checkbox:checked").css("display", "none");
    	            $("#CheckBoxList_jianding :checkbox:checked").next().css("display", "none");
    	            $("#CheckBoxList_jianding input:not(:checked)").css("display", "");
    	            $("#CheckBoxList_jianding input:not(:checked)").next().css("display", "");

    	        }
    	        if ($(this).val() == "1") {
    	            $("#CheckBoxList_jianding :checkbox:checked").css("display", "");
    	            $("#CheckBoxList_jianding :checkbox:checked").next().css("display", "");
    	            $("#CheckBoxList_jianding input:not(:checked)").css("display", "none");
    	            $("#CheckBoxList_jianding input:not(:checked)").next().css("display", "none");

    	        }
    	        if ($(this).val() == "%") {
    	            $("#CheckBoxList_jianding input").css("display", "");
    	            $("#CheckBoxList_jianding input").next().css("display", "");
    	        }
    	    });

    	    //打开鉴定 选择窗口
    	    $("#dialog_jianding").dialog({ autoOpen: false, width: 800, height: 600, buttons: {
    	        "提交": function() {
    	            if (JiandingSetVal()) {
    	                $(this).dialog("close");
    	                $("#tb_jianding").blur();
    	            }
    	        }, "取消": function() {
    	            $(this).dialog("close");
    	            $("#tb_jianding").blur();
    	        }
    	    }
    	    });
    	    $("#tb_jianding").focus(function() { $("#dialog_jianding").dialog("open"); });

    	    // 类型选择后 打开相应的版块
    	    $("#rbl_leixing input").click(function() {
    	        leixing = $(this).val();
    	        $("#hd_leixing").val(leixing)
    	        if (leixing == "2") {
    	            $("#CBL_cailiao1 input").each(function() { $(this).attr("disabled", "disabled"); $(this).prop("checked", false); });
    	            $("#CBL_cailiao2 input").each(function() { $(this).attr({ disabled: false }) });
    	        }
    	        else if (leixing == "1") {
    	            $("#CBL_cailiao2 input").each(function() { $(this).attr("disabled", "disabled"); $(this).prop("checked", false); });
    	            $("#CBL_cailiao1 input").each(function() { $(this).attr({ disabled: false }) });
    	        }
    	    }
    	);

    	    // 点击特定的材料  打开相应的输入框比如房产证等
    	    $("#CBL_cailiao1 input").click(function() {
    	        check_cailiao($(this));
    	        cailiao_checked = $(this);
    	    }
    	);
    	    $("#CBL_cailiao2 input").click(function() {
    	        check_cailiao($(this));
    	        cailiao_checked = $(this);
    	    }
    	);

    	    //路段选择 对话框的输入语句
    	    $("#dialog_lu").dialog({ autoOpen: false, width: 800, height: 600, buttons: {
    	        "提交": function() {
    	            if (setValue()) {
    	                $(this).dialog("close");
    	            }
    	        }, "取消": function() {
    	            $(this).dialog("close");
    	        }
    	    }
    	    });

    	    $(".xianqu").each(function() {
    	        $(this).change(function() {
    	            $(this).parent().next().find(".lu").val("");
    	        });
    	    });


    	    //材料房产证的js  实现 输入姓名后在页面上即时的显示功能
    	    $("#dialog_cailiao_fangcanzheng").dialog({ autoOpen: false, width: 500, height: 300, buttons: {
    	        "提交": function() {
    	            //  var b=$(this).find("input");
    	            var b = $("#tb_fangcan2").val();
    	            //var a=$("#ddl_guanxi_cailiao1 option:selected").html();
    	            var a = $("#tb_fangcan4").val();
    	            b = b.replace(/\s+/g, "");

    	            var strfangcan = $("#lb_fangcan1").text() + $("#tb_fangcan2").val() + $("#lb_fangcan3").text() + $("#tb_fangcan4").val();
    	           
    	            var aaa = cailiaoObj.text().substring(0, 2);
    	          
    	            //合并写入一个字段
    	            //去除重复序号
    	            if (cailiaoObjValue == null) {
    	                cailiaoObjValue = $("#hd_cailiaoObjValue").val();
    	            }
    	            var cvindex = cailiaoObjValue.indexOf(aaa, 0);
    	            // cailiaoObjValue.substring(0,2)==aaa;
    	            if (cvindex >= 0) {
    	                var arrCailiao = cailiaoObjValue.split('$');
    	                //int arrlenth=0;
    	                var arrlenth = arrCailiao.length;
    	                for (var iarr = 0; iarr < arrlenth - 1; iarr++) {
    	                    if (arrCailiao[iarr].substring(0, 2) == aaa) {
    	                        cailiaoObjValue= cailiaoObjValue.replace(arrCailiao[iarr], aaa + $("#tb_fangcan2").val() + "|" + $("#tb_fangcan4").val())
    	                        bealcailiao = true;
    	                        break;
    	                    }
    	                }
    	            }
    	            else {
    	                cailiaoObjValue += aaa + $("#tb_fangcan2").val() + "|" + $("#tb_fangcan4").val() + "$";
    	            }
    	            //写入隐藏域供后台读取

    	           
    	            $("#hd_cailiaoObjValue").val(cailiaoObjValue);
    	           // alert($("#hd_cailiaoObjValue").val());
    	            if (leixing == "1") {

    	                $("#CBL_cailiao1 label:contains('" + aaa + "')").html(strfangcan);
    	            }
    	            else if (leixing == "2") {
    	                $("#CBL_cailiao2 label:contains('" + aaa + "')'").html(strfangcan);
    	            }
    	            $(this).dialog("close");



    	        }, "取消": function() {
    	            cailiao_checked.prop("checked", false);
    	            $(this).dialog("close");
    	        }
    	    }
    	    });

    	    //材料合同的js 的弹出框代码 实现 输入姓名关系后即时的显示功能
    	    $("#dialog_cailiao_hetong").dialog({ autoOpen: false, width: 500, height: 300, buttons: {
    	        "提交": function() {
    	            var strfangcan = $("#lb_hetong1").text() + $("#tb_hetong2").val() + $("#lb_hetong3").text() + $("#ddl_guanxi_cailiao2 option:selected").html();
    	            if (leixing == "1") {
    	                $("#CBL_cailiao1 label:contains('购房合同')").html(strfangcan)
    	            }
    	            else if (leixing == "2") {
    	                $("#CBL_cailiao2 label:contains('购房合同')").html(strfangcan)
    	            }

    	            $(this).dialog("close");

    	        }, "取消": function() {
    	            $(this).dialog("close");
    	        }
    	    }
    	    });

    	    // 定义简历弹出对话框
    	    $("#dialog_jianli").dialog({ autoOpen: false, width: 400, height: 420, buttons: {
    	        "提交": function() {
    	            jianli_index += 1;
    	            $("#jianli_index").val(jianli_index)
    	            var id_li = "#jianli" + jianli_index;
    	            var id_time1 = "#jianli" + jianli_index + "2";
    	            var id_time2 = "#jianli" + jianli_index + "3";
    	            var id_jianli = "#jianli" + jianli_index + "1";
    	            $(id_time1).val($("#jianli_time1").val());
    	            $(id_time2).val($("#jianli_time2").val());
    	            $(id_jianli).val($("#jianli").val());
    	            $("#jianli_time1").val("");
    	            $("#jianli_time2").val("");
    	            $("#jianli").val("");
    	            $(id_li).css("display", "");

    	            if (old_index != 0) {
    	                jianli_index = old_index;
    	                old_index = 0;
    	            }
    	            if (jianli_index == 3) {
    	                $("#jianliadd1").css("display", "none");
    	            }

    	            $(this).dialog("close");
    	        }, "取消": function() {
    	            $("#jianli_time1").val("");
    	            $("#jianli_time2").val("");
    	            $("#jianli").val("");
    	            if (old_index != 0) {
    	                jianli_index = old_index;
    	                old_index = 0;
    	            }
    	            $(this).dialog("close");
    	        }
    	    }

    	    });
    	    //上传照片对话框
    	    $("#dialog").dialog({ autoOpen: false, width: 400, height: 420, buttons: {
    	        "上传": function() {
    	            $("#Button1").click();
    	            $(this).dialog("close");
    	        },
    	        "取消": function() {
    	            $(this).dialog("close");
    	        }

    	    }
    	    });

    	    $(".lu").each(function() {
    	        $(this).focus(function() {
    	            lu_focus = $(this);
    	            var d = lu_focus.parent().prev().find(".xianqu").find("option:selected").text();

    	            // var d=lu_focus.parent().next();
    	            if (d != "请选择") {
    	                var e = lu_focus.parent().prev().find(".xianqu").find("option:selected").val();
    	                $(".rbl_lu").each(function() {
    	                    var rbl_id = $(this).attr("id");
    	                    var jint = rbl_id.indexOf(e, 0);
    	                    if (jint > 0) {
    	                        $(this).css("display", "");
    	                        $("#rdl_lu_Id").val(rbl_id);
    	                    }
    	                    else {
    	                        $(this).css("display", "none");
    	                    }
    	                });
    	                if (e != $("#hd_xianqu").val()) {
    	                    var f = lu_focus.parent().prev().find(".xianqu").attr("id");
    	                    $("#change_xianqu").val(f);
    	                    var g = $("#change_xianqu").val();
    	                    $("#bt_xianqu1").click();
    	                }
    	                $("#dialog_lu").dialog("open")
    	            }
    	            else {
    	                alert("请先选者县区!");
    	                lu_focus.blur();
    	            };
    	        });
    	    });

    	    //把各个对话框加入form1 让其控件可以回发服务器
    	    $("#dialog_cailiao_fangcanzheng").parent().appendTo($("#form1"));
    	    $("#dialog_cailiao_hetong").parent().appendTo($("#form1"));
    	    $("#dialog").parent().appendTo($("#form1"));
    	});
				// 判断点击材料的项，符合条件的打开相应的对话框 
				
				function check_cailiao(cailiao)
				{
               

                if (cailiao.prop("checked")) {

                    //定义数组　定义出现弹窗的菜单
                    var arrCailiaoKey = new Array();

                    if (leixing == "1") {
                        arrCailiaoKey[0] = 1;
                        arrCailiaoKey[1] = 6;
                    }
                    else {
                        arrCailiaoKey[0] = 1;
                        arrCailiaoKey[1] = 8;

                    }

                    var arrCailiaoKey_isOpen = new Array();
                    if (leixing == "1") {
                        arrCailiaoKey_isOpen[0] = 2;
                        arrCailiaoKey_isOpen[1] = 3;
                        arrCailiaoKey_isOpen[2] = 4;
                        arrCailiaoKey_isOpen[3] = 5;

                    }
                    else {

                        arrCailiaoKey_isOpen[0] = 2;
                        arrCailiaoKey_isOpen[1] = 3;
                        arrCailiaoKey_isOpen[2] = 4;
                        arrCailiaoKey_isOpen[3] = 5;
                        arrCailiaoKey_isOpen[4] = 6;
                        arrCailiaoKey_isOpen[5] = 7;
                    }

                    var cailiao_context = cailiao.parent().text();
                    
                    cailiaoObj = cailiao.parent();
                    var opencailiao = true;
                    var cailiao_index = cailiao_context.substring(0, 1);
                    for (arrlen = 0; arrlen < arrCailiaoKey.length; arrlen++) {
                        if (cailiao_index == arrCailiaoKey[arrlen]) {
                            opencailiao = false;
                            break;
                        }
                    }
                    if (opencailiao) {

                        var duandian1 = cailiao_context.indexOf("（", 0);
                        var duandian2 = cailiao_context.indexOf("）", 0);
                        var duandian3 = cailiao_context.indexOf("系_");
                        var duandian2length = cailiao_context.length - duandian2;
                        if (duandian1 > 0) {
                            $("#lb_fangcan1").text(cailiao_context.substring(0, duandian1 + 1));
                            $("#lb_fangcan3").text("");
                        }
                        if (duandian3 > 0 && duandian2 > 0) {
                            $("#lb_fangcan3").text(cailiao_context.substring(duandian2, duandian3 + 2));
                            $("#tb_fangcan4").css("display", "block");
                        }
                        else if (duandian3 < 0 && duandian2 > 0) {
                            $("#lb_fangcan3").text(cailiao_context.substring(duandian2, cailiao_context.length));
                            $("#tb_fangcan4").css("display", "none");
                            $("#tb_fangcan4").val("");
                        } else {

                            $("#lb_fangcan3").text("");
                            $("#tb_fangcan4").css("display", "none");
                            $("#tb_fangcan4").val("");
                        }

                        //打开对话框
                        $("#dialog_cailiao_fangcanzheng").dialog("open");
                        
                       if (cailiaoObjValue == null) {
                        cailiaoObjValue = $("#hd_cailiaoObjValue").val();
                    }
                     var arrCailiao = cailiaoObjValue.split('$');
                    if (cailiaoObjValue != "") {
                        for (arrlen = 0; arrlen < arrCailiaoKey_isOpen.length; arrlen++) {

                            if (cailiao_index == arrCailiaoKey_isOpen[arrlen]) {
                                var x1 = $.trim((arrCailiao[arrCailiaoKey_isOpen[arrlen] - 1])).split('|');
                                //打开对话框之前初始化对话框
                               

                                if (duandian1 > 0) {
                                    $("#lb_fangcan1").text(cailiao_context.substring(0, duandian1 + 1));
                                    $("#lb_fangcan3").text("");
                                    $("#tb_fangcan2").val($.trim(x1[0].substring(1, 10)).substring(1, 10));
                                }
                                if (duandian3 > 0 && duandian2 > 0) {
                                    $("#lb_fangcan3").text(cailiao_context.substring(duandian2, duandian3+2));
                                    $("#tb_fangcan4").css("display", "block");
                                    $("#tb_fangcan4").val($.trim(x1[1]));
                                }
                                else if (duandian3 < 0 && duandian2 > 0) {
                                $("#lb_fangcan3").text(cailiao_context.substring(duandian2, cailiao_context.length));
                                    $("#tb_fangcan4").css("display", "none");
                                    $("#tb_fangcan4").val("");
                                } else {

                                    $("#lb_fangcan3").text("");
                                    $("#tb_fangcan4").css("display", "none");
                                    $("#tb_fangcan4").val("");
                                }

                                //打开对话框
                               // $("#dialog_cailiao_fangcanzheng").dialog("open");
                            }
                        }

                    
                    }
                       
                    }
                }
              	
	            }
			
        	//删除简历		
	        function  deljianli(c)
	        {
	        var zuidajianli  = jianli_index;
		    var id_li="#jianli"+zuidajianli; 

		    for(var i=c+1;i<=zuidajianli ;i++)
		    {
		     var id1_time1="#jianli"+i+"2";
		     var id1_time2="#jianli"+i+"3";
		     var id1_jianli="#jianli"+i+"1";
		     var id2_time1="#jianli"+(i-1)+"2";
		     var id2_time2="#jianli"+(i-1)+"3";
		     var id2_jianli="#jianli"+(i-1)+"1";
		     $(id2_time1).val($(id1_time1).val());
		     $(id2_time2).val($(id1_time2).val());
		     $(id2_jianli).val($(id1_jianli).val());
		     $(id1_time1).val("");
		     $(id1_time2).val("") ;
		     $(id1_jianli).val("");
		    }
		    var jianli=$(id_li);
			jianli[0].style.display="none";
			jianli_index-=1;
			$("#jianli_index").val(jianli_index)
			if(jianli_index<3)
			{
			$("#jianliadd1").css("display","");
			}
			
			return  false ;
		     
	        }
			
			
			// 修改简历
			function jianliupdate(c)
			{
			        old_index=jianli_index;
			        jianli_index=c-1;
			    	var	id_time1="#jianli"+c+"2";
				    var id_time2="#jianli"+c+"3";
				    var id_jianli="#jianli"+c+"1";
				    $("#jianli_time1").val($(id_time1).val());
					$("#jianli_time2").val($(id_time2).val());
					$("#jianli").val($(id_jianli).val());
			    $("#dialog_jianli").dialog("open");
				return  false;
			}					
			
			//增加简历
			function  jianliadd()
			{
				$("#dialog_jianli").dialog("open");
				return  false;
			
			}
			
			//打开上传相片对话框
                function opendilog()
                {
              if($("#tb_bianhao").val()!=""){
	                $("#dialog").dialog("open");
                	
		              
		                }
		                else {
		                alert("请先输入全部信息并保存后，在上传相片！！")
		                }
		                  return false;
                }
                function setQianyue()
                {
                var shenfenzheng= $("#tb_shenfenzheng").val();
                var lenght=  shenfenzheng .length;
                if(lenght==18)
                {
                var nian=shenfenzheng .substr(6,4);
                var yue=shenfenzheng .substr(10,2);
                var ri=shenfenzheng .substr(12,2);
                
                 $("#tb_chushengnianyue").val(nian+"-"+yue+"-"+ri);
                }
                
                }
                
                
                   	//查找筛选对应的路段的值


                $(document).ready(function() {
                    // 材料框的可用性设置为 不可用
                    leixing = $("#hd_leixing").val();
                    if (leixing == "1") {
                    $("#CBL_cailiao2 input").each(function() { $(this).attr("disabled", "disabled") });
                     } else if (leixing == "2") {
                    $("#CBL_cailiao1 input").each(function() { $(this).attr("disabled", "disabled") });
                }
                else {
                    $("#CBL_cailiao2 input").each(function() { $(this).attr("disabled", "disabled") });
                    $("#CBL_cailiao1 input").each(function() { $(this).attr("disabled", "disabled") });
                }
                    
                    
                   

                    //回发服务器的时候 重新显示简历
                    jianli_index = parseInt($("#jianli_index").val());
                    for (var j = 1; j <= jianli_index; j++) {
                        var id_li = "#jianli" + j;
                        $(id_li).css("display", "");
                    }
                    //重新绑定 实际住址代码
                    $("#Label_zhuzhi1").text($("#hd_zhuzhi1").val());
                    $("#Label_zhuzhi2").text($("#hd_zhuzhi2").val());
                    //材料cheakboxlist 中显示页面回发前的数据

                    
                    //合并写入一个字段
                    //去除重复序号    	             
                    //定义数组　定义出现弹窗的菜单
                    var arrCailiaoKey = new Array();
                    if (leixing == "1") {
                        arrCailiaoKey[0] = 2;
                        arrCailiaoKey[1] = 3;
                        arrCailiaoKey[2] = 4;
                        arrCailiaoKey[3] = 5;

                    }
                    else {

                        arrCailiaoKey[0] = 2;
                        arrCailiaoKey[1] = 3;
                        arrCailiaoKey[2] = 4;
                        arrCailiaoKey[3] = 5;
                        arrCailiaoKey[4] = 6;
                        arrCailiaoKey[5] = 7;
                    }

                    if (cailiaoObjValue == null) {
                        cailiaoObjValue = $("#hd_cailiaoObjValue").val();
                    }
                    
                    if (cailiaoObjValue != "") {
                        
                        var arrCailiao = cailiaoObjValue.split('$');
                        var bealcailiao = true;

                        for (arrlen = 0; arrlen < arrCailiaoKey.length; arrlen++) {
                            var clkey1;
                            var cailiao_context = "";
                            if (leixing == "1") {
                                clkey1 = $("#CBL_cailiao1 label:contains('" + arrCailiaoKey[arrlen] + "、" + "')");
                            } else {
                                clkey1 = $("#CBL_cailiao2 label:contains('" + arrCailiaoKey[arrlen] + "、" + "')");
                            }
                            cailiao_context = clkey1.html();
                            var duandian1 = cailiao_context.indexOf("（", 0);
                            var duandian2 = cailiao_context.indexOf("）", 0);
                            var duandian3 = cailiao_context.indexOf("系_");
                            // var duandian2length=strfangcan1.length-duandian3+2;

                            var duandian2length = cailiao_context.length - duandian2;


                            //               if (duandian1 > 0) {
                            //                   $("#lb_fangcan1").text(cailiao_context.substring(0, duandian1 + 1));
                            //               }
                            //               if (duandian3 > 0 && duandian2 > 0) {
                            //                   $("#lb_fangcan3").text(cailiao_context.substring(duandian2, cailiao_context.length));
                            //                   $("#tb_fangcan4").css("display", "block");
                            //               }
                            //               else if (duandian3 < 0 && duandian2 > 0) {
                            //                   $("#lb_fangcan3").text(cailiao_context.substring(duandian2, cailiao_context.length));
                            //                   $("#tb_fangcan4").css("display", "none");
                            //               } else {

                            //                   $("#lb_fangcan3").text("");
                            //                   $("#tb_fangcan4").css("display", "none");
                            //               }

                            var cailiaostr1 = "";

                            var cailiaostr2 = "";

                            var cailiaostr3 = "";
                            if (duandian1 > 0) {
                                cailiaostr1 = cailiao_context.substring(0, duandian1 + 1);
                            }

                            if (duandian3 > 0 && duandian2 > 0) {
                                cailiaostr2 = cailiao_context.substring(duandian2, cailiao_context.lenght)

                            }
                            else if (duandian3 < 0 && duandian2 > 0) {
                                cailiaostr2 = cailiao_context.substring(duandian2, cailiao_context.lenght);
                            }
                            else {
                                cailiaostr1 = cailiao_context;

                            }
                            var x1 = $.trim((arrCailiao[arrCailiaoKey[arrlen] - 1])).split('|');
                            //                var x2 = arrCailiao[arrCailiaoKey[arrlen] - 1].split('|');
                            //
                            var cailiao_context_real = cailiaostr1 + x1[0].substring(2, x1[0].lenght) + cailiaostr2 + x1[1];
                            clkey1.html(cailiao_context_real);
                            cailiao_context_real = "";
                        }
                    }


                    //        var strfangcan1 =$("#lb_hetong1").text()+$("#tb_hetong2").val()+$("#lb_hetong3").text()+$("#ddl_guanxi_cailiao2 option:selected").html();
                    //        var strfangcan2 =$("#lb_fangcan1").text()+$("#tb_fangcan2").val()+$("#lb_fangcan3").text()+$("#tb_fangcan4").val();
                    //          if(leixing=="1")
                    //         {   	
                    //         
                    //         $("#CBL_cailiao1 input").each(function (){$(this).attr({disabled:false})});        
                    //          $("#CBL_cailiao1 label:contains('购房合同')").html(strfangcan1);
                    //          $("#CBL_cailiao1 label:contains('房产证。产权人姓名')").html(strfangcan2);
                    //         }
                    //         else  if( leixing =="2")
                    //         {    	        
                    //          $("#CBL_cailiao2 input").each(function (){$(this).attr({disabled:false})}); 
                    //          $("#CBL_cailiao2 label:contains('购房合同')").html(strfangcan1);
                    //          $("#CBL_cailiao2 label:contains('房产证。产权人姓名')").html(strfangcan2);
                    //         }
                    //         else if(leixing=="0")
                    //         {
                    //            $("#CBL_cailiao1 label:contains('购房合同')").html(strfangcan1)
                    //              $("#CBL_cailiao2 label:contains('购房合同')").html(strfangcan1)
                    //              $("#CBL_cailiao1 label:contains('房产证。产权人姓名')").html(strfangcan2)
                    //           $("#CBL_cailiao2 label:contains('房产证。产权人姓名')").html(strfangcan2)
                    //         
                    //         }


                    //         if(leixing=="1")
                    //         {   	        
                    //          $("#CBL_cailiao1 label:contains("房产证。产权人姓名")").html(strfangcan2)
                    //         }
                    //         else  if( leixing =="2")
                    //         {    	         
                    //          $("#CBL_cailiao2 label:contains("房产证。产权人姓名")").html(strfangcan2)
                    //         }
                    //         else if(leixing=="0")
                    //         {
                    //           $("#CBL_cailiao1 label:contains("房产证。产权人姓名")").html(strfangcan2)
                    //           $("#CBL_cailiao2 label:contains("房产证。产权人姓名")").html(strfangcan2)
                    //         }
                    //绑定合同材料 姓名 关系

                    //定义缩略图的使用的控件
                    var file1 = document.getElementById("FileUpload1");
                    var img1 = document.getElementById("idImg");
                    var ip = new ImagePreview(file1, img1, { maxWidth: 200, maxHeight: 200, action: "ImagePreview.ashx" });
                    ip.img.src = ImagePreview.TRANSPARENT;
                    //缩略图使用的触发条件
                    ip.file.onchange = function() { ip.preview(); };
                });
        
        
        