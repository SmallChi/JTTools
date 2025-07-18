
axios.defaults.baseURL = "https://jttools.smallchi.cn/jtt";

//axios.defaults.baseURL = "http://127.0.0.1:18889/jtt";

function hexToString(hexStr) {
    // 移除可能存在的空格和换行符
    hexStr = hexStr.replace(/\s+/g, '');
    // 将16进制字符串转换为字节数组
    let bytes = [];
    for (let i = 0; i < hexStr.length; i += 2) {
        bytes.push(parseInt(hexStr.substring(i, i + 2), 16));
    }
    // 将字节数组转换为字符串
    return String.fromCharCode.apply(null, bytes);
}

/*ref: https://kimi.moonshot.cn/  auto-generated code */
jQuery.fn.extend({
    autoHeight: function () {
        return this.each(function () {
            var $this = jQuery(this);
            if (!$this.attr('_initAdjustHeight')) {
                $this.attr('_initAdjustHeight', $this.outerHeight());
            }
            _adjustH(this).on('input', function () {
                _adjustH(this);
            });
        });
        function _adjustH(elem) {
            var $obj = jQuery(elem);
            return $obj.css({ height: $obj.attr('_initAdjustHeight'), 'overflow-y': 'hidden' })
                .height(elem.scrollHeight);
        }
    }
});

$(document).ready(function () {
    const JT808HexData = "7E 02 00 00 26 12 34 56 78 90 12 00 7D 02 00 00 00 01 00 00 00 02 00 BA 7F 0E 07 E4 F1 1C 00 28 00 3C 00 00 18 10 15 10 10 10 01 04 00 00 00 64 02 02 00 7D 01 13 7E";
    const JT8082013ForceHexData = "7e0102400c01003000068109024a3130303330303030363831857e";
    const JT808JT1078HexData = "7E120523A204066657506200EB00020001015A00000023012012191042052012191050190000000000000000000101064446D10120121910221720121910420500000000000000000001010F1FE8EB0120121910023420121910221700000000000000000001010F182D5C0120121909471120121910015500000000000000000001010B38F2430120121909274020121909471100000000000000000001010F056DB40120121909080920121909274000000000000000000001010F0724380120121908483820121909080900000000000000000001010F0530AB0120121908290720121908483800000000000000000001010F05896C0120121908093720121908290700000000000000000001010F02CD3B0120121907500520121908093700000000000000000001010F056FEF0120121907303420121907500500000000000000000001010F043C3401201219072541201219073034000000000000000000010103C26C5F0120121907061120121907254100000000000000000001010F03F0C10120121906464220121907061100000000000000000001010F02F6330120121906271220121906464200000000000000000001010F02E43B0120121906074220121906271200000000000000000001010F033D670120121905481120121906074200000000000000000001010F088BF20120121905284120121905481100000000000000000001010F03F9FE0120121905091020121905284100000000000000000001010F05B1040120121904494020121905091000000000000000000001010F02B3540120121904301020121904494000000000000000000001010F0417B00120121904103920121904301000000000000000000001010F0538970120121903510820121904103900000000000000000001010F054E9E0120121903313820121903510800000000000000000001010F016ECB0120121903120820121903313800000000000000000001010F0333C00120121902523820121903120700000000000000000001010F029D230120121902330720121902523700000000000000000001010F0354E40120121902133720121902330700000000000000000001010F03303D0120121901540720121902133700000000000000000001010F04981E0120121901343720121901540700000000000000000001010F02AD940120121901150820121901343700000000000000000001010EFFD7CF0120121900553720121901150800000000000000000001010F07D9330120121900360720121900553700000000000000000001010F040E740C7E\n7E1205203804066657506200EC000200020120121900163320121900360700000000000000000001010F0CE4CD0120121900002220121900163300000000000000000001010C6F9E7B5D7E";
    const JT808YueBiaoHexData = "7E0200405C01000000000012345678913CC400000000008C0003015198CF06C158C5000801F200E52203151206110104000716E30302000014040000000015040000000016040000000017020000180300000025040000000030011F310117EF0D49249200000049249011000003DE7E\n7E0200405C01000000000012345678913CC400000000008C0003015198CF06C158C5000801F200E52203151206110104000716E30302000014040000000015040000000016040000000017020000180300000025040000000030011F310117EF0D49249200000049249011000003DE7E";
    const JT808GPS51HexData = "7e020000470412106280030233000000000000200201d365df072f15d500280000002d21091719155801040002a10f2a0200042b049203a46f520103eb06000100ce0a5730011b31010951080000000000000000ca7e";
    const JT19056UpHexData = "55 7A C4 00 00 00 EB";
    const JT19056DownHexData = "55 7A C4 00 14 00 20 03 25 10 26 01 20 03 25 10 26 01 00 00 12 34 00 12 34 56 A9";
    const JT905HexData = "7E02000023103456789012007D02000000010000000200BA7F0E07E4F11C003C002110152110100104000000640202007D01347E";
    const JTSBHexData = "30 31 63 64 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 61 6C 61 72 6D 2E 78 6C 73 78 00 00 00 01 00 00 00 05 01 02 03 04 05";
    const JT1078HexData = "30 31 63 64 81 E2 10 88 01 12 34 56 78 10 01 10 00 00 01 6B B3 92 CA 7C 02 80 00 28 00 2E 00 00 00 01 61 E1 A2 BF 00 98 CF C0 EE 1E 17 28 34 07 78 8E 39 A4 03 FD DB D1 D5 46 BF B0 63 01 3F 59 AC 34 C9 7A 02 1A B9 6A 28 A4 2C 08";
    const JT809HexData2011 = "5B 00 00 00 92 00 00 06 82 94 00 01 33 EF B8 01 00 00 00 00 00 27 0F D4 C1 41 31 32 33 34 35 00 00 00 00 00 00 00 00 00 00 00 00 00 02 94 01 00 00 00 5C 01 00 02 00 00 00 00 5A 01 AC 3F 40 12 3F FA A1 00 00 00 00 5A 01 AC 4D 50 03 73 6D 61 6C 6C 63 68 69 00 00 00 00 00 00 00 00 31 32 33 34 35 36 37 38 39 30 31 00 00 00 00 00 00 00 00 00 31 32 33 34 35 36 40 71 71 2E 63 6F 6D 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 BA D8 5D";
    const JT809HexData2019 = "5B 00 00 00 C9 00 00 06 82 17 00 01 34 15 F4 01 00 00 00 00 00 27 0F 00 00 00 00 5E 02 A5 07 B8 D4 C1 41 31 32 33 34 35 00 00 00 00 00 00 00 00 00 00 00 00 00 02 17 01 00 00 00 8B 01 02 03 04 05 06 07 08 09 10 11 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 E7 D3 5D";
    const HexTools = "68747470733a2f2f6a74746f6f6c732e736d616c6c6368692e636e\n68747470733a2f2f67707335312e636f6d2f232f6c6f67696e";
    var route_state = 0;
    var navbarCollapse = new bootstrap.Collapse('#navbarCollapse', {
        toggle: false
    });
    var carousel = new bootstrap.Carousel('#ProductCarousel', {
        interval: 2000,
        touch: false
    });
    $("#JT808_Hex").val(JT808HexData);
    $("#JT809_Hex").val(JT809HexData2011);
    $("#JT19056_Hex").val(JT19056UpHexData);
    $("#JT905_Hex").val(JT905HexData);
    $("#JTSB_Hex").val(JTSBHexData);
    $("#JT1078_Hex").val(JT1078HexData);
    $("#HexTools").val(HexTools);

    window.addEventListener('load', function () {
        console.log('load location: ', document.location, 'state: ', event.state);
        var MenuTypeHash = window.location.hash;
        if (MenuTypeHash) {
            console.log(MenuTypeHash);
            $("#menus>li a").removeClass('active');
            $("#menus>li a[menu-type=" + MenuTypeHash.substring(1) + "]").addClass('active');
            $("#main>div.container").hide();
            $("#main>div.container").removeClass("hide");
            $(MenuTypeHash).fadeIn();
            navbarCollapse.hide();
        }
    });

    /* 使用history API和监听popstate事件 */
    window.addEventListener('popstate', function (event) {
        if (route_state == 1) {
            route_state = 0;
            return;
        }
        console.log('popstate location: ', document.location, 'state: ', event.state);
        var MenuTypeHash = window.location.hash;
        if (MenuTypeHash) {
            console.log(MenuTypeHash);
            $("#menus>li a").removeClass('active');
            $("#menus>li a[menu-type=" + MenuTypeHash.substring(1) + "]").addClass('active');
            $("#main>div.container").hide();
            $("#main>div.container").removeClass("hide");
            $(MenuTypeHash).fadeIn();
            navbarCollapse.hide();
        }
    });

    $("#menus>li a").on("click", function () {
        route_state = 1;
        $("#menus>li a").removeClass('active');
        $(this).addClass('active');
        var currentMenuType = $(this).attr("menu-type");
        // console.debug(currentMenuType);
        // console.debug($("#main>div.container"));
        $("#main>div.container").hide();
        $("#main>div.container").removeClass("hide");
        $("#" + currentMenuType).fadeIn();
        navbarCollapse.hide();
    });

    $("#JT808_ProtocolType").on("change", function () {
        var protocolType = $(this).val();
        var hexData = JT808HexData;
        if ("JT808_JT1078" == protocolType) {
            hexData = JT808JT1078HexData;
        }
        else if ("JT808_YueBiao" == protocolType) {
            hexData = JT808YueBiaoHexData;
        }
        else if ("JT2013Force" == protocolType) {
            hexData = JT8082013ForceHexData;
        }
        else if ("JT808_GPS51" == protocolType) {
            hexData = JT808GPS51HexData;
        }
        $("#JT808_Hex").val(hexData);
        $("#JT808_Hex").autoHeight();
        //$("#JT809_Result").text("");
    });

    $("#JT809_ProtocolType").on("change", function () {
        var selectedValue = $(this).val();
        if (selectedValue == "2011") {
            $("#JT809_Hex").val(JT809HexData2011);
        } else {
            $("#JT809_Hex").val(JT809HexData2019);
        }
        $("#JT809_Result").text("");
    });

    $("#JT809_EncryptType").on("change", function () {
        var selectedValue = $(this).val();
        if (selectedValue == "none") {
            $("#JT809_Encrypt_Group").fadeOut();
        } else {
            $("#JT809_Encrypt_Group").fadeIn();
        }
    });

    $("#JT19056_ProtocolType").on("change", function () {
        var selectedValue = $(this).val();
        if (selectedValue == "up") {
            $("#JT19056_Hex").val(JT19056UpHexData);
        } else {
            $("#JT19056_Hex").val(JT19056DownHexData);
        }
        $("#JT19056_Result").text("");
    });

    $("#HexToolsConvert").on("click", function () {
        var hexLines = $("#HexTools").val().split('\n');
        var hexStr = "";
        if (hexLines) {
            for (var i = 0; i < hexLines.length; i++) {
                var hex = hexToString(hexLines[i]);
                hexStr += hex + "\n";
            }
        }
        $("#HexToolsResult").val(hexStr);
    });

    $("#HexToolsDemo").on("click", function () {
        $("#HexTools").val(HexTools);
    });

    $("#HexToolsClear").on("click", function () {
        $("#HexTools").val("");
        $("#HexToolsResult").val("");
    });

    $("#JT808_Parse").on("click", function () {
        axios.post("/JT808/Analyze",
            {
                Hex: $("#JT808_Hex").val(),
                ProtocolType: $("#JT808_ProtocolType").val()
            }).then((res) => {
                // console.debug(res);
                if (res.data.Code == 200) {
                    $('#JT808_Accordion_Result').html("");
                    if (res.data.Result.Packages) {
                        $.each(res.data.Result.Packages, function (index, item) {
                            var accordionHeader_content = '';
                            accordionHeader_content += '<span class="badge text-bg-primary">终端号：' + item.TerminalPhoneNo + '</span>';
                            accordionHeader_content += '<span class="badge text-bg-secondary">消息Id：' + item.MsgId + '</span>';
                            accordionHeader_content += '<span class="badge text-bg-success">消息流水号：' + item.MsgNum + '</span>';
                            accordionHeader_content += '<span class="badge text-bg-danger">设备版本号：' + item.ProtocolVersion + '</span>';
                            accordionHeader_content += '<span class="badge text-bg-warning">总分包数：' + item.PackgeCount + '</span>';
                            accordionHeader_content += '<span class="badge text-bg-info">当前页：' + item.PackageIndex + '</span>';
                            accordionHeader_content += '<span class="badge text-bg-dark">数据体长度：' + item.DataLength + '</span>';
                            accordionHeader_content += '<span class="badge text-bg-light">是否加密：' + (item.Encrypt ? '是' : '否') + '</span>';
                            var accordionHeader = '<h2 class="accordion-header"><button class="accordion-button" type="button" data-bs-target="#collapse' + index + '" aria-expanded="false" aria-controls="collapse' + index + '">' + '序号:' + item.Order + accordionHeader_content + '</button></h2>';
                            var accordionBody = '<div id="collapse' + index + '" class="accordion-collapse collapse"><div class="accordion-body"><pre>' + item.Body + '</pre></div></div>';
                            var accordionItem = '<div class="accordion-item">' + accordionHeader + accordionBody + '</div>';
                            $('#JT808_Accordion_Result').append(accordionItem);
                        });
                        if (res.data.Result.IsSubpackage) {
                            var index = res.data.Result.Packages.length + 1;
                            var accordionHeader = '<h2 class="accordion-header"><button class="accordion-button" type="button" data-bs-target="#collapse' + index + '" aria-expanded="false" aria-controls="collapse' + index + '">' + '合并数据体' + '</button></h2>';
                            var accordionBody = '<div id="collapse' + index + '" class="accordion-collapse collapse"><div class="accordion-body"><pre>' + res.data.Result.JsonValue + '</pre></div></div>';
                            var accordionItem = '<div class="accordion-item">' + accordionHeader + accordionBody + '</div>';
                            $('#JT808_Accordion_Result').append(accordionItem);
                        }
                        $('#JT808_Accordion_Result div.accordion-collapse').addClass('show');
                    } else {
                        $('#JT808_Accordion_Result').html("处理异常，请检测对应Hex数据包");
                    }

                } else {
                    $("#JT808_Accordion_Result").html(res.data.Message);
                }
            });
    });

    $("#JT809_Parse").on("click", function () {
        axios.post("/JT809/Analyze",
            {
                Hex: $("#JT809_Hex").val(),
                ProtocolType: $("#JT809_ProtocolType").val(),
                IsEncrypt: $("#JT809_EncryptType").val() == "none",
                M1: parseInt($("#JT809_M1_Value").val()),
                IA1: parseInt($("#JT809_IA1_Value").val()),
                IC1: parseInt($("#JT809_IC1_Value").val()),
            }).then((res) => {
                console.debug(res);
                if (res.data.Code == 200) {
                    console.debug(res.data.Result.JsonValue);
                    $("#JT809_Result").text(res.data.Result.JsonValue);
                } else {
                    $("#JT809_Result").text(res.data.Message);
                }
            });
    });

    $("#JT19056_Parse").on("click", function () {
        axios.post("/JT19056/Analyze",
            {
                Hex: $("#JT19056_Hex").val(),
                ProtocolType: $("#JT19056_ProtocolType").val()
            }).then((res) => {
                console.debug(res);
                if (res.data.Code == 200) {
                    console.debug(res.data.Result.JsonValue);
                    $("#JT19056_Result").text(res.data.Result.JsonValue);
                } else {
                    $("#JT19056_Result").text(res.data.Message);
                }
            });
    });

    $("#JT905_Parse").on("click", function () {
        axios.post("/JT905/Analyze",
            {
                Hex: $("#JT905_Hex").val()
            }).then((res) => {
                console.debug(res);
                if (res.data.Code == 200) {
                    console.debug(res.data.Result.JsonValue);
                    $("#JT905_Result").text(res.data.Result.JsonValue);
                } else {
                    $("#JT905_Result").text(res.data.Message);
                }
            });
    });

    $("#JTSB_Parse").on("click", function () {
        axios.post("/JTActiveSafety/Analyze",
            {
                Hex: $("#JTSB_Hex").val()
            }).then((res) => {
                console.debug(res);
                if (res.data.Code == 200) {
                    console.debug(res.data.Result.JsonValue);
                    $("#JTSB_Result").text(res.data.Result.JsonValue);
                } else {
                    $("#JTSB_Result").text(res.data.Message);
                }
            });
    });

    $("#JT1078_Parse").on("click", function () {
        axios.post("/JT1078/Analyze",
            {
                Hex: $("#JT1078_Hex").val()
            }).then((res) => {
                console.debug(res);
                if (res.data.Code == 200) {
                    console.debug(res.data.Result.JsonValue);
                    $("#JT1078_Result").text(res.data.Result.JsonValue);
                } else {
                    $("#JT1078_Result").text(res.data.Message);
                }
            });
    });

    $("#ProductAD_GPS51").on("click", function () {
        window.open("https://gps51.com/#/login?username=001test&password=Aa1357", '_blank');
    });

    $("#ProductAD_GPS51_AI").on("click", function () {
        window.open("https://gps51.com/#/login?username=001test&password=Aa1357", '_blank');
    });
});