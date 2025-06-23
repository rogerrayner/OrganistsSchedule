using AutoMapper;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using System.Globalization;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Application.Services;

public class ExportService(IMapper mapper) : IExportService
{
    public byte[] ExportHolyServicesToExcel(IEnumerable<HolyService> holyServices)
    {
        if (holyServices == null)
            throw new ArgumentNullException(nameof(holyServices));
        
        ExcelPackage.License.SetNonCommercialOrganization("Congregação Cristã no Brasil - Joinville");
        using var package = new ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add("Dias de Culto");

        worksheet.Cells[1, 1].Value = "Data";
        worksheet.Cells[1, 2].Value = "Congregação";
        worksheet.Cells[1, 3].Value = "Organista";
        worksheet.Cells[1, 4].Value = "Organista - Nome Curto";
        worksheet.Cells[1, 5].Value = "Reunião de Jovens?";
        
        // Formatação dos cabeçalhos
        using (var range = worksheet.Cells[1, 1, 1, 5])
        {
            range.Style.Font.Bold = true;
            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
            range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
            range.Style.Border.BorderAround(ExcelBorderStyle.Thin);
        }

        // Largura das colunas
        for (int col = 1; col <= 4; col++)
            worksheet.Column(col).Width = 20;        
        int row = 2;
        foreach (var hs in holyServices)
        {
            worksheet.Cells[row, 1].Value = hs.Date.ToString("dd/MM - ddd", new CultureInfo("pt-BR"));
            worksheet.Cells[row, 2].Value = hs.Congregation.Name;
            worksheet.Cells[row, 3].Value = hs.Organist.FullName;
            worksheet.Cells[row, 4].Value = hs.Organist.ShortName;
            worksheet.Cells[row, 5].Value = hs.IsYouthMeeting ? "x" : string.Empty;
            row++;
        }
        
        // Adiciona borda em cada célula da linha
        for (int col = 1; col <= 4; col++)
        {
            worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin);
        }
        row++;
        
        // Centraliza as colunas Data (1) e Reunião de Jovens? (4)
        worksheet.Cells[2, 1, row - 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        worksheet.Cells[2, 5, row - 1, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

        return package.GetAsByteArray();
    }
}