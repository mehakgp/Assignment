window.jsPDF = window.jspdf.jsPDF;
document.getElementById('exportPdf').addEventListener('click', function () {
    const urlParams = new URLSearchParams(window.location.search);

    const month = urlParams.get('month');
    const year = urlParams.get('year');

    var fileName = 'SummaryReport.pdf';

    var doc = new jsPDF();
    doc.text("Appointment Summary Report - " + month + "/" + year, 10, 10);
    var table = document.getElementById('reportTable');
    doc.autoTable({ html: table });
    doc.save(fileName);
});