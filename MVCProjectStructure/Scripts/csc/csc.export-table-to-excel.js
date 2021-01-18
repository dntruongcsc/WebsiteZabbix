//Cách 1
//Cách dùng fnExcelReport(IdTable)
function fnExcelReport(IdTable) {
    var tab_text = "<table border='1px'><tr>";
    var textRange; var j = 0;
    tab = document.getElementById(IdTable); // id of table

    for (j = 0; j < tab.rows.length; j++) {
        tab_text = tab_text + tab.rows[j].innerHTML + "</tr>";
    }

    tab_text = tab_text + "</table>";
    tab_text = tab_text.replace(/<A[^>]*>|<\/A>/g, "");//remove if u want links in your table
    tab_text = tab_text.replace(/<img[^>]*>/gi, ""); // remove if u want images in your table
    tab_text = tab_text.replace(/<input[^>]*>|<\/input>/gi, ""); // reomves input params

    var ua = window.navigator.userAgent;
    var msie = ua.indexOf("MSIE ");

    if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./))      // If Internet Explorer
    {
        txtArea1.document.open("txt/html", "replace");
        txtArea1.document.write(tab_text);
        txtArea1.document.close();
        txtArea1.focus();
        sa = txtArea1.document.execCommand("SaveAs", true, "Say Thanks to Sumit.xls");
    }
    else                 //other browser not tested on IE 11
        sa = window.open('data:application/vnd.ms-excel,' + encodeURIComponent(tab_text));

    return (sa);
}

//Cách 2
//chuyển sang base 64 
//cách dùng TableToExcel(<IdTable>,<sheet name>)
function TableToExcel(Idtable, title, fileName, sheetName) {
        var uri = 'data:application/vnd.ms-excel;base64,'
            , template = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--><meta http-equiv="content-type" content="text/plain; charset=UTF-8"/></head><body><table>{table}</table></body></html>'
            , base64 = function (s) { return window.btoa(unescape(encodeURIComponent(s))); }
            , format = function (s, c) { return s.replace(/{(\w+)}/g, function (m, p) { return c[p]; }); };
        if (!Idtable.nodeType) {
            var tab_text = "<table border='1px'>";
            var j = 0;
            table = document.getElementById(Idtable); // id of table
            if (title)
                tab_text += "<tr><td style='text-align: center; font-weight: bold;' colspan='" + table.rows[0].childElementCount + "'>" + title + "</td></tr>";
            for (j = 0; j < table.rows.length; j++) {
                tab_text = tab_text + "<tr>" + table.rows[j].innerHTML + "</tr>";
            }

            tab_text = tab_text + "</table>";
            tab_text = tab_text.replace(/<A[^>]*>|<\/A>/g, "");//remove if u want links in your table
            tab_text = tab_text.replace(/<a[^>]*>|<\/a>/g, "");//remove if u want links in your table
            tab_text = tab_text.replace(/<img[^>]*>/gi, ""); // remove if u want images in your table
            tab_text = tab_text.replace(/<input[^>]*>|<\/input>/gi, ""); // reomves input params

            var ctx = { worksheet: sheetName || 'Worksheet', table: tab_text };

            //Không được xoá
            //if (navigator.msSaveBlob) {
            //    var blob = new Blob([format(template, ctx)], { type: 'application/vnd.ms-Excel', endings: 'native' });
            //    navigator.msSaveBlob(blob, 'export.xls');
            //} else {
            //    window.location.href = uri + base64(format(template, ctx));
            //}

            //Tạm dùng 
            var a = document.createElement('a');
            a.href = uri + base64(format(template, ctx));
            a.download = (fileName ? fileName :'table_name') + '.xls';
            a.click();
        }
    }
