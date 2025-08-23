using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace OrganistsSchedule.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous] // Permite acesso sem autenticação
    public class HealthController : ControllerBase
    {
        private static readonly DateTime _startTime = DateTime.UtcNow;

        /// <summary>
        /// Endpoint principal de health check - retorna informações detalhadas da API
        /// </summary>
        /// <returns>Status da API com informações detalhadas</returns>
        [HttpGet]
        [ProducesResponseType(typeof(HealthCheckResponse), 200)]
        public IActionResult GetHealth()
        {
            try
            {
                var response = new HealthCheckResponse
                {
                    Status = "Healthy",
                    Timestamp = DateTime.UtcNow,
                    Version = GetApiVersion(),
                    Service = "OrganistsSchedule API",
                    Uptime = GetUptime(),
                    Environment = GetEnvironment()
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new HealthCheckResponse
                {
                    Status = "Unhealthy",
                    Timestamp = DateTime.UtcNow,
                    Version = GetApiVersion(),
                    Service = "OrganistsSchedule API",
                    Error = ex.Message
                };

                return StatusCode(500, errorResponse);
            }
        }

        /// <summary>
        /// Endpoint simples de ping - retorna apenas "pong"
        /// </summary>
        /// <returns>Resposta simples de ping</returns>
        [HttpGet("ping")]
        [ProducesResponseType(typeof(PingResponse), 200)]
        public IActionResult Ping()
        {
            var response = new PingResponse
            {
                Message = "Pong",
                Timestamp = DateTime.UtcNow
            };

            return Ok(response);
        }

        /// <summary>
        /// Endpoint de status detalhado - inclui informações do sistema
        /// </summary>
        /// <returns>Status detalhado da aplicação</returns>
        [HttpGet("status")]
        [ProducesResponseType(typeof(DetailedHealthResponse), 200)]
        public IActionResult GetDetailedStatus()
        {
            try
            {
                var response = new DetailedHealthResponse
                {
                    Status = "Healthy",
                    Timestamp = DateTime.UtcNow,
                    Service = "OrganistsSchedule API",
                    Version = GetApiVersion(),
                    Environment = GetEnvironment(),
                    Uptime = GetUptime(),
                    UptimeSeconds = GetUptimeSeconds(),
                    ServerTime = DateTime.UtcNow,
                    LocalTime = DateTime.Now,
                    MachineName = Environment.MachineName,
                    ProcessorCount = Environment.ProcessorCount,
                    WorkingSet = Environment.WorkingSet,
                    Endpoints = new List<string>
                    {
                        "/api/health",
                        "/api/health/ping", 
                        "/api/health/status",
                        "/api/congregations",
                        "/api/organists",
                        "/api/holy-services"
                    }
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new DetailedHealthResponse
                {
                    Status = "Unhealthy",
                    Timestamp = DateTime.UtcNow,
                    Service = "OrganistsSchedule API",
                    Error = ex.Message
                };

                return StatusCode(500, errorResponse);
            }
        }

        private string GetApiVersion()
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var version = assembly.GetName().Version;
                return version?.ToString() ?? "1.0.0";
            }
            catch
            {
                return "1.0.0";
            }
        }

        private string GetEnvironment()
        {
            return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Unknown";
        }

        private string GetUptime()
        {
            var uptime = DateTime.UtcNow - _startTime;
            return $"{uptime.Days}d {uptime.Hours}h {uptime.Minutes}m {uptime.Seconds}s";
        }

        private long GetUptimeSeconds()
        {
            return (long)(DateTime.UtcNow - _startTime).TotalSeconds;
        }
    }

    #region Response Models

    public class HealthCheckResponse
    {
        public string Status { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public string Version { get; set; } = string.Empty;
        public string Service { get; set; } = string.Empty;
        public string? Uptime { get; set; }
        public string? Environment { get; set; }
        public string? Error { get; set; }
    }

    public class PingResponse
    {
        public string Message { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
    }

    public class DetailedHealthResponse
    {
        public string Status { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public string Service { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public string? Environment { get; set; }
        public string? Uptime { get; set; }
        public long UptimeSeconds { get; set; }
        public DateTime ServerTime { get; set; }
        public DateTime LocalTime { get; set; }
        public string MachineName { get; set; } = string.Empty;
        public int ProcessorCount { get; set; }
        public long WorkingSet { get; set; }
        public List<string> Endpoints { get; set; } = new();
        public string? Error { get; set; }
    }

    #endregion
}