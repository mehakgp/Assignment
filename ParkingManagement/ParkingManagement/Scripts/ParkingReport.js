window.jsPDF = window.jspdf.jsPDF;
document.getElementById('exportPdf').addEventListener('click', function () {
    var selectedDate = document.getElementById('selectedDate').value;
    var fileName = 'report_' + selectedDate + '.pdf';

    var doc = new jsPDF();
    doc.text("Parking Zone Report", 10, 10);
    var table = document.getElementById('reportTable');
    doc.autoTable({ html: table });
    doc.save(fileName);
});