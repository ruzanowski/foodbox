﻿using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.Configuration;
using Abp.Localization;
using Abp.MultiTenancy;
using Abp.Net.Mail;

namespace Food.EntityFrameworkCore.Seed.Host
{
    public class DefaultSettingsCreator
    {
        private readonly FoodDbContext _context;

        public DefaultSettingsCreator(FoodDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            int? tenantId = null;

            if (FoodConsts.MultiTenancyEnabled == false)
            {
                tenantId = MultiTenancyConsts.DefaultTenantId;
            }

            // Emailing
            AddSettingIfNotExists(EmailSettingNames.DefaultFromAddress, "zamowienia@fitruna.pl", tenantId);
            AddSettingIfNotExists(EmailSettingNames.DefaultFromDisplayName, "fitruna.pl mailer", tenantId);

            // Languages
            AddSettingIfNotExists(LocalizationSettingNames.DefaultLanguage, "pl", tenantId);
        }

        private void AddSettingIfNotExists(string name, string value, int? tenantId = null)
        {
            if (_context.Settings.IgnoreQueryFilters().Any(s => s.Name == name && s.TenantId == tenantId && s.UserId == null))
            {
                return;
            }

            _context.Settings.Add(new Setting(tenantId, null, name, value));
            _context.SaveChanges();
        }
    }
}
