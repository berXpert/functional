var app = WebApplication.Create();

var handleSaveTransfer = ConfigureSaveTransferHandler(app.Configuration);

app.MapPost("/Transfer/Future", handleSaveTransfer);

await app.RunAsync();