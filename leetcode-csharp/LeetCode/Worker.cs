// Licensed to the Trickyrat under one or more agreements.
// The Trickyrat licenses this file to you under the MIT license.

namespace LeetCode;

public class Worker(ILogger<Worker> logger
    , IHost host) : BackgroundService
{
    private readonly ILogger _logger = logger;
    private readonly IHost _host = host;
    private int _exitCode = 0;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            _logger.LogInformation("Worker running at: {Now}", DateTime.Now);
            // Add your service here
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception: {Message}", ex.Message);
            _exitCode = -1;
            throw;
        }
        finally
        {
            Environment.ExitCode = _exitCode;
            await _host.StopAsync(stoppingToken);
        }
    }
}