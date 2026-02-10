using Terminal.Gui;
using Cli.Styles;
using Features;
using System.Data;

namespace Cli.Views.Files;

public class ViewFilesView : View {
    public ViewFilesView(){
        Title = "File Configuration";
        Width = Dim.Fill();
        Height = Dim.Fill();
        BorderStyle = DefaultStyles.GetDefaultBorderLineStyle();

        List<BackupFile> backupFiles = Features.Files.GetBackupFileList();
        TableView tableView = new ()
        {
            Title = "Backup Files",
            Width = Dim.Fill(),
            Height = Dim.Fill()
        };
        DataTable backupFilesDataTable = Features.Files.CreateFileListDataTable(backupFiles);
        tableView.Table = new DataTableSource(backupFilesDataTable);
        Add(tableView);
    }
}

