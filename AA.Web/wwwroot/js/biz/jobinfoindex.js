$(function () {
    //提示信息
    var lang = {
        "sProcessing": "处理中...",
        "sLengthMenu": "每页显示 _MENU_ 条记录",
        "sZeroRecords": "没有检索到数据",
        "sInfo": "从 _START_ 到 _END_ /共 _TOTAL_ 条数据。",
        "sInfoEmpty": "没有数据",
        "sInfoFiltered": "(由 _MAX_ 条数据中检索)",
        "sInfoPostFix": "",
        "sSearch": "搜索:",
        "sUrl": "",
        "sEmptyTable": "表中数据为空",
        "sLoadingRecords": "载入中...",
        "sInfoThousands": ",",
        "oPaginate": {
            "sFirst": "首页",
            "sPrevious": "上页",
            "sNext": "下页",
            "sLast": "末页",
            "sJump": "跳转"
        },
        "oAria": {
            "sSortAscending": ": 以升序排列此列",
            "sSortDescending": ": 以降序排列此列"
        }
    };

    //初始化表格
    var jobTable = $("#job_list").dataTable({
        "language": lang,  //提示信息
        autoWidth: false,  //禁用自动调整列宽
        stripeClasses: ["odd", "even"],  //为奇偶行加上样式，兼容不支持CSS伪类的场合
        processing: true,  //隐藏加载提示,自行处理
        serverSide: true,  //启用服务器端分页
        searching: true,  //禁用原生搜索
        "ordering": false,
        orderMulti: false,  //启用多列排序
        order: [],  //取消默认排序查询,否则复选框一列会出现小箭头
        dom: 'lBrtip',//隐藏搜索框
        renderer: "bootstrap",  //渲染样式：Bootstrap和jquery-ui
        pagingType: "simple_numbers",  //分页样式：simple,simple_numbers,full,full_numbers
        columnDefs: [{
            "targets": 'nosort',  //列的样式名
            "orderable": false    //包含上样式名‘nosort’的禁止排序
        }],
        ajax: function (data, callback, settings) {
            //封装请求参数
            var param = {};
            param.limit = data.length;//页面显示记录条数，在页面显示每页显示多少项的时候
            param.start = data.start;//开始的记录序号
            param.page = (data.start / data.length) + 1;//当前页码
            param.draw = data.draw;
            param.UserName = data.search.value;
            //console.log(param);
            console.log(data);
            //ajax请求数据
            $.ajax({
                type: "GET",
                url: "/JobInfo/GetListQuartzJobdetail",
                cache: false,  //禁用缓存
                data: param,  //传入组装的参数
                dataType: "json",
                success: function (result) {
                    //console.log(result);
                    //setTimeout仅为测试延迟效果
                    setTimeout(function () {
                        //封装返回数据
                        var returnData = {};
                        returnData.draw = result.draw;//这里直接自行返回了draw计数器,应该由后台返回
                        returnData.recordsTotal = result.recordsTotal;//返回数据全部记录
                        returnData.recordsFiltered = result.recordsTotal;//后台不实现过滤功能，每次查询均视作全部结果
                        returnData.data = result.data;//返回的数据列表
                        //console.log(returnData);
                        //调用DataTables提供的callback方法，代表数据已封装完成并传回DataTables进行渲染
                        //此时的数据需确保正确无误，异常判断应在执行此回调前自行处理完毕
                        callback(returnData);
                    }, 200);
                }
            });
        },
        "columns": [
            {
                "data": "id",
                "bSortable": false,
            },
            {
                "data": "jobGroup",
                "bSortable": false,
            },
            {
                "data": "jobName",
                "bSortable": false,
            },
            {
                "data": "runStatus",
                "bSortable": false,

                "bSortable": false,
                "width": '10%',
                "render": function (data, type, row) {

                    // status
                    if (data && data != 'NONE') {
                        if ('NORMAL' == data) {
                            return '<small class="label label-success" ><i class="fa fa-clock-o"></i>RUNNING</small>';
                        } else {
                            return '<small class="label label-warning" >ERROR(' + data + ')</small>';
                        }
                    } else {
                        return '<small class="label label-default" ><i class="fa fa-clock-o"></i>STOP</small>';
                    }

                    return data;
                }
            },

            {
                "data": "cron",
                "width": '15%',
                "bSortable": false,
            },
            {
                "data": "startTime",
                "bSortable": false,
                "render": function (data, type, row) {
                    return data ? moment(new Date(data)).format("YYYY年MM月DD日 HH:mm:ss") : "";
                }
            },
            {
                "data": "endTime",
                "bSortable": false,
                "render": function (data, type, row) {
                    return data ? moment(new Date(data)).format("YYYY年MM月DD日 HH:mm:ss") : "";
                }
            },
            {
                "data": "description",
                "bSortable": false,
            },
            {
                "data": "apiUrl",
                "bSortable": false,
            },

            {
                "data": "status",
                "bSortable": false,
                "bSortable": false,
                "width": '10%',
                "render": function (data, type, row) {

                    // status
                    if (data && data != 'NONE') {
                        if ('NORMAL' == data) {
                            return '<small class="label label-success" ><i class="fa fa-clock-o"></i>启用</small>';
                        } else {
                            return '<small class="label label-warning" >ERROR(' + data + ')</small>';
                        }
                    } else {
                        return '<small class="label label-default" ><i class="fa fa-clock-o"></i>STOP</small>';
                    }

                    return data;
                }


            },
            {
                "data": "gmtCreateTime",
                "bSortable": false,
                "render": function (data, type, row) {
                    return data ? moment(new Date(data)).format("YYYY年MM月DD日 HH:mm:ss") : "";
                }
            },
            {
                "data": "job_operate",
                "width": '15%',
                "bSortable": false,
                "render": function (data, type, row) {
                    return function () {
                        // status
                        var start_stop = "";
                        if (row.runStatus && row.runStatus != 'NONE') {
                            if ('NORMAL' == row.runStatus) {
                                start_stop = '<button class="btn btn-primary btn-xs job_operate" _type="job_pause" type="button">停止 </button>  ';
                            } else {
                                start_stop = '<button class="btn btn-primary btn-xs job_operate" _type="job_pause" type="button">停止 </button>  ';
                            }
                        } else {
                            start_stop = '<button class="btn btn-primary btn-xs job_operate" _type="job_resume" type="button">启动</button>  ';
                        }

                        // log url
                        var logUrl = "/" + '/?jobId=' + row.id;

                        //// log url
                        //var codeBtn = "";
                        //if ('BEAN' != row.glueType) {
                        //    var codeUrl = base_url + '/jobcode?jobId=' + row.id;
                        //    codeBtn = '<a href="' + codeUrl + '" target="_blank" > <button class="btn btn-warning btn-xs" type="button" >GLUE</button> </a> '
                        //}

                        // html
                        tableData['key' + row.id] = row;
                        var html = '<p id="' + row.id + '" >' +
                            /* '<button class="btn btn-primary btn-xs job_trigger" type="button">执行</button>  ' */
                            '<button class="btn btn-primary btn-xs job_operate" _type="job_resume" type="button">启动</button>  ' +
                            start_stop +
                            //'<a href="' + logUrl + '"> <button class="btn btn-primary btn-xs" type="job_del" type="button" >日志</button> </a> <br>  ' +
                            '<button class="btn btn-warning btn-xs update" type="button">编辑</button>  ' +
                            '<button class="btn btn-danger btn-xs job_operate" _type="job_del" type="button">删除</button>  ' +
                            '</p>';

                        return html;
                    };
                }
            }

        ]
    }).api();
    //此处需调用api()方法,否则返回的是JQuery对象而不是DataTables的API对象

    // table data
    var tableData = {};

    $("#btsearch").on("click", function () {
        var filter = $('#inputUserName').val();
        jobTable.search(filter).draw();
    });

    // job operate
    $("#job_list").on('click', '.job_operate', function () {
        var typeName;
        var url;
        var needFresh = false;
        var base_url = "";
        var type = $(this).attr("_type");
        if ("job_pause" == type) {
            typeName = "停止";
            url = base_url + "/JobInfo/PauseJob";
            needFresh = true;
        } else if ("job_resume" == type) {
            typeName = "启动";
            url = base_url + "/JobInfo/RunJob";
            needFresh = true;
        } else if ("job_del" == type) {
            typeName = "删除";
            url = base_url + "/jobinfo/remove";
            needFresh = true;
        } else {
            return;
        }

        var id = $(this).parent('p').attr("id");

        layer.confirm("确定" + typeName + '?', {
            icon: 3,
            title: "系统提示",
            btn: ["确定", "取消"]
        }, function (index) {
            layer.close(index);
            // jobTable.fnDraw(false);
            console.log(url);
            $.ajax({
                type: 'POST',
                url: url,
                data: {
                    "id": id
                },
                dataType: "json",
                success: function (data) {
                    layer.open({
                        title: "系统提示",
                        btn: "确定",
                        content: typeName + "成功",
                        icon: '1',
                     
                    });
                },
            });
        });
    });

    // add
    $(".add").click(function () {
        $('#addModal').modal({ backdrop: false, keyboard: false }).modal('show');
    });

    var addModalValidate = $("#addModal .form").validate({
        errorElement: 'span',
        errorClass: 'help-block',
        focusInvalid: true,
        rules: {
            JobName: {
                required: true,
                maxlength: 50
            },
            JobGroup: {
                required: true
            },
            Cron: {
                required: true
            },
            Description: {
                required: true,
            },
            StartTime: {
                required: true,
            }
            ,
            EndTime: {
                required: true,
            }
            ,
            ApiUrl: {
                required: true,
            }

        },
        messages: {

            JobName: {
                required: "请输入任务名称"
            },
            JobGroup: {
                required: "请输入任务组"
            },
            Cron: {
                required: "请输入Cron"
            }
            ,
            ApiUrl: {
                required: "请输入服务接口"
            }
            ,
            StartTime: {
                required: "请输入运行开始时间"
            }
            ,
            EndTime: {
                required: "请输入运行结束时间"
            }

            ,

            Description: {
                required: "请输入任务描述"
            }


        },
        highlight: function (element) {
            $(element).closest('.form-group').addClass('has-error');
        },
        success: function (label) {
            label.closest('.form-group').removeClass('has-error');
            label.remove();
        },
        errorPlacement: function (error, element) {
            element.parent('div').append(error);
        },
        submitHandler: function (form) {

            // process

            var para = {
                JobName: $("#addModal .form input[name='JobName']").val(),
                JobGroup: $("#addModal .form input[name='JobGroup']").val(),
                Cron: $("#addModal .form input[name='Cron']").val(),
                ApiUrl: $("#addModal .form input[name='ApiUrl']").val(),
                StartTime: $("#addModal .form input[name='StartTime']").val(),
                EndTime: $("#addModal .form input[name='EndTime']").val(),
                Description: $("#addModal .form input[name='Description']").val(),
            };

            var url = "/Jobinfo/Save";
            $.ajax({
                type: 'POST',
                url: url,
                data: para,
                dataType: "json",
                success: function (data) {
                    jobTable.draw(false); //isSuccess
                    layer.msg(data.message, { icon: 1, time: 1500 });
                    if (data.isSuccess)
                    {
                        $('#addModal').modal('hide');
                    }
                }
            });
          
        }
    });
    $("#addModal").on('hide.bs.modal', function () {
        $("#addModal .form")[0].reset();
        addModalValidate.resetForm();
        $("#addModal .form .form-group").removeClass("has-error");
    });

    // update
    $("#job_list").on('click', '.update', function () {

        var id = $(this).parent('p').attr("id");
        var row = tableData['key' + id];
        console.log(row);
        // base data
        $("#updateModal .form input[name='id']").val(row.id);
        $("#updateModal .form input[name='JobName']").val(row.jobName);
        $("#updateModal .form input[name='JobGroup']").val(row.jobGroup);
        $("#updateModal .form input[name='Cron']").val(row.cron);
        $("#updateModal .form input[name='Description']").val(row.description);
        $("#updateModal .form input[name='StartTime']").val(row.startTime);
        $("#updateModal .form input[name='EndTime']").val(row.endTime);
        $("#updateModal .form input[name='ApiUrl']").val(row.apiUrl);
        $('#updateModal').modal({ backdrop: false, keyboard: false }).modal('show');
    });
    var updateModalValidate = $("#updateModal .form").validate({
        errorElement: 'span',
        errorClass: 'help-block',
        focusInvalid: true,

        rules: {
            JobName: {
                required: true,
                maxlength: 50
            },
            JobGroup: {
                required: true
            },
            Cron: {
                required: true
            },
            Description: {
                required: true,
            },
            StartTime: {
                required: true,
            }
            ,
            EndTime: {
                required: true,
            }
            ,
            ApiUrl: {
                required: true,
            }

        },
        messages: {

            JobName: {
                required: "请输入任务名称"
            },
            JobGroup: {
                required: "请输入任务组"
            },
            Cron: {
                required: "请输入Cron"
            },
            Description: {
                required: "请输入任务描述"
            },
            StartTime: {
                required: "请输入运行开始时间"
            }
            ,
            EndTime: {
                required: "请输入运行结束时间"
            }
            ,
            ApiUrl: {
                required: "请输入服务接口"
            }




        },
        highlight: function (element) {
            $(element).closest('.form-group').addClass('has-error');
        },
        success: function (label) {
            label.closest('.form-group').removeClass('has-error');
            label.remove();
        },
        errorPlacement: function (error, element) {
            element.parent('div').append(error);
        },
        submitHandler: function (form) {
            var para = {
                Id: $("#updateModal .form input[name='id']").val(),
                JobName: $("#updateModal .form input[name='JobName']").val(),
                JobGroup: $("#updateModal .form input[name='JobGroup']").val(),
                Cron: $("#updateModal .form input[name='Cron']").val(),
                ApiUrl: $("#updateModal .form input[name='ApiUrl']").val(),
                StartTime: $("#updateModal .form input[name='StartTime']").val(),
                EndTime: $("#updateModal .form input[name='EndTime']").val(),
                Description: $("#updateModal .form input[name='Description']").val(),
            };

            var url = "/Jobinfo/Update";
            $.ajax({
                type: 'POST',
                url: url,
                data: para,
                dataType: "json",
                success: function (data) {
                    jobTable.draw(false);
                    layer.msg(data.message, { icon: 1, time: 1500 });
                    if (data.isSuccess) {
                        $('#updateModal').modal('hide');
                    }
                }
            });
        }
    });
    $("#updateModal").on('hide.bs.modal', function () {
        $("#updateModal .form")[0].reset();
    });

})