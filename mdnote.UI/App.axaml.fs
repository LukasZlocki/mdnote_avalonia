namespace mdnote.UI

open Avalonia
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.Markup.Xaml
open mdnote.Application
open mdnote.Infrastructure

type App() =
    inherit Application()

    override this.Initialize() =
            AvaloniaXamlLoader.Load(this)

    override this.OnFrameworkInitializationCompleted() =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime as desktop ->
             let repository = JsonWindowPositionRepository()
             let windowPositionService = WindowPositionService(repository)
             let lastOpenedFileRepository = JsonLastOpenedFileRepository()
             let lastOpenedFileService = LastOpenedFileService(lastOpenedFileRepository)
             let fileReader = FileTextReader()
             let fileWriter = FileTextWriter()
             let textFileService = TextFileService(fileReader, fileWriter)
             desktop.MainWindow <- MainWindow(windowPositionService, textFileService, lastOpenedFileService)
        | _ -> ()

        base.OnFrameworkInitializationCompleted()
