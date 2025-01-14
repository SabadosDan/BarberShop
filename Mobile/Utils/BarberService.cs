﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;

namespace Mobile.Utils
{

    public class BarberService
    {
        private static readonly string ApiUrl = DeviceInfo.Platform == DevicePlatform.Android
         ? "http://10.0.2.2:5145"
         : "http://localhost:5145";
        private HttpClient _httpClient;

        public BarberService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(ApiUrl);
        }

        public async Task<List<Barber>> GetBarbersWithServicesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{ApiUrl}/api/barbers");

                if (response.IsSuccessStatusCode)
                {
                    var barbers = await response.Content.ReadFromJsonAsync<List<Barber>>();
                    return barbers ?? new List<Barber>();
                }
                else
                {
                    throw new Exception("Failed to load barbers");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching barbers: " + ex.Message);
            }
        }

        public async Task<List<Service>> GetServicesByBarberIdAsync(int barberId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{ApiUrl}/api/services/barber/{barberId}");

                if (response.IsSuccessStatusCode)
                {
                    var services = await response.Content.ReadFromJsonAsync<List<Service>>();
                    return services ?? new List<Service>();
                }
                else
                {
                    throw new Exception("Failed to load services for barber.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching services: " + ex.Message);
            }
        }

        public async Task<bool> CheckAvailability(int barberId, DateTime dateTime)
        {
            var response = await _httpClient.GetAsync($"{ApiUrl}/api/appointments/available?barberId={barberId}&dateTime={dateTime}");

            if (response.IsSuccessStatusCode)
            {
                var isAvailable = await response.Content.ReadFromJsonAsync<bool>();
                return isAvailable;
            }
            return false;
        }
        public async Task<bool> BookAppointment(Appointment appointment)
        {
            var response = await _httpClient.PostAsJsonAsync($"{ApiUrl}/api/appointments", appointment);

            return response.IsSuccessStatusCode;
        }

        public async Task<List<Appointment>> GetAppointmentsByClientIdAsync(int clientId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{ApiUrl}/api/appointments/{clientId}");

                if (response.IsSuccessStatusCode)
                {
                    var appointments = await response.Content.ReadFromJsonAsync<List<Appointment>>();
                    return appointments;
                }
                else
                {
                    throw new Exception("Failed to load appointments.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching appointments: " + ex.Message);
            }
        }


    }
}
