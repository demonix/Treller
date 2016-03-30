using System;
using System.Collections.Generic;
using System.Linq;
using SKBKontur.Treller.WebApplication.Implementation.Infrastructure.Storages;
using SKBKontur.Treller.WebApplication.Implementation.RoundDance.BusinessObjects;

namespace SKBKontur.Treller.WebApplication.Implementation.RoundDance
{
    public class RoundDancePeopleStorage : IRoundDancePeopleStorage
    {
        private readonly ICachedFileStorage cachedFileStorage;
        private readonly RoundDancePeople[] startVariant;
        private Dictionary<string, RoundDancePeople> peoples;
        private const string FileName = "RoundDancePeoples";

        public RoundDancePeopleStorage(ICachedFileStorage cachedFileStorage)
        {
            this.cachedFileStorage = cachedFileStorage;

            #region default people storage
            startVariant = new[]
            {
#region peoples left
                //                new RoundDancePeople { Name = "��� ������", Email = "scalder@skbkontur.ru",
//                    WorkPeriods = new []
//                    {
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 07, 27), DefaultDirection = DefaultDirection.Infrastructure },
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 08, 17), DefaultDirection = DefaultDirection.Leave },
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 08, 31), DefaultDirection = DefaultDirection.Infrastructure },
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 09, 07), DefaultDirection = DefaultDirection.LinksDeliveryAgent },
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 10, 05), DefaultDirection = DefaultDirection.SpeedyFeatures },
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 12, 15), DefaultDirection = DefaultDirection.Sickness },
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 12, 17), DefaultDirection = DefaultDirection.SpeedyFeatures },
//                    }},

//                new RoundDancePeople { Name = "������ ���������", Email = "oksanchike@skbkontur.ru",
//                    WorkPeriods = new []
//                    {
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 08, 24), DefaultDirection = DefaultDirection.ProlongationScenario, },
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 10, 09), DefaultDirection = DefaultDirection.Infrastructure, },
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 11, 05), DefaultDirection = DefaultDirection.SpeedyFeatures},
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 11, 25), DefaultDirection = DefaultDirection.Fisics},
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 11, 30), DefaultDirection = DefaultDirection.Leave},
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 12, 03), DefaultDirection = DefaultDirection.Fisics},
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 12, 07), DefaultDirection = DefaultDirection.Infrastructure},
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 12, 10), DefaultDirection = DefaultDirection.SpeedyFeatures},
//                    }},

//                new RoundDancePeople { Name = "���� �����������", Email = "logicman@skbkontur.ru",
//                    WorkPeriods = new []
//                    {
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 04, 06), DefaultDirection = DefaultDirection.�aServices, },
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 05, 18), DefaultDirection = DefaultDirection.ProductBilling,  },
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 06, 20), DefaultDirection = DefaultDirection.Infrastructure,  },
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 07, 06), DefaultDirection = DefaultDirection.Support, },
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 08, 20), DefaultDirection = DefaultDirection.Vendors, },
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 09, 08), DefaultDirection = DefaultDirection.RomingDiadoc, },
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 09, 21), DefaultDirection = DefaultDirection.CaMigration, },
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 10, 05), DefaultDirection = DefaultDirection.SpeedyFeatures, },
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 10, 12), DefaultDirection = DefaultDirection.RomingDiadoc, },
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 11, 19), DefaultDirection = DefaultDirection.Leave, },
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 11, 24), DefaultDirection = DefaultDirection.RomingDiadoc, },
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 12, 08), DefaultDirection = DefaultDirection.SpeedyFeatures, },
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 12, 14), DefaultDirection = DefaultDirection.Duty },
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 12, 21), DefaultDirection = DefaultDirection.SpeedyFeatures },
//                        new DirectionPeriod { BeginDate = new DateTime(2016, 01, 13), DefaultDirection = DefaultDirection.Infrastructure },
//                        new DirectionPeriod { BeginDate = new DateTime(2016, 01, 18), DefaultDirection = DefaultDirection.SpeedyFeatures },
//                        new DirectionPeriod { BeginDate = new DateTime(2016, 01, 25), DefaultDirection = DefaultDirection.Infrastructure, },
//                        new DirectionPeriod { BeginDate = new DateTime(2016, 02, 01), DefaultDirection = DefaultDirection.SpeedyFeatures, },
//                        new DirectionPeriod { BeginDate = new DateTime(2016, 02, 15), DefaultDirection = DefaultDirection.Leave },
//                    }},
//                new RoundDancePeople { Name = "������ �����", Email = "s.rozhin@skbkontur.ru",
//                    WorkPeriods = new []
//                    {
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 04, 06), DefaultDirection = DefaultDirection.�aServices,  },
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 07, 13), DefaultDirection = DefaultDirection.Support, },
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 08, 12), DefaultDirection = DefaultDirection.Leave, },
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 08, 31), DefaultDirection = DefaultDirection.Duty, },
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 09, 07), DefaultDirection = DefaultDirection.SpeedyFeatures, },
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 10, 26), DefaultDirection = DefaultDirection.Duty, },
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 11, 03), DefaultDirection = DefaultDirection.SpeedyFeatures},
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 11, 16), DefaultDirection = DefaultDirection.Infrastructure},
//                        new DirectionPeriod { BeginDate = new DateTime(2015, 11, 30), DefaultDirection = DefaultDirection.Certificates},
//                        new DirectionPeriod { BeginDate = new DateTime(2016, 02, 08), DefaultDirection = DefaultDirection.Leave},
//                    }},
                // DefaultDirection = Support
                // DefaultDirection = ProductBilling
#endregion
                new RoundDancePeople { Name = "���� ��������", Email = "fea@skbkontur.ru",
                    WorkPeriods = new List<DirectionPeriod>
                    {
                        new DirectionPeriod { BeginDate = new DateTime(2015, 04, 06), DefaultDirection = Direction.ProductBilling },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 06, 30), DefaultDirection = Direction.Crm },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 08, 25), DefaultDirection = Direction.SpeedyFeatures },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 09, 11), DefaultDirection = Direction.Leave },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 09, 28), DefaultDirection = Direction.SpeedyFeatures },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 10, 29), DefaultDirection = Direction.Fisics },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 12, 14), DefaultDirection = Direction.Duty },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 12, 21), DefaultDirection = Direction.SpeedyFeatures },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 01, 19), DefaultDirection = Direction.Infrastructure },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 02, 08), DefaultDirection = Direction.Duty },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 02, 15), DefaultDirection = Direction.SpeedyFeatures, PairName = "�������"},
                        new DirectionPeriod { BeginDate = new DateTime(2016, 03, 09), DefaultDirection = Direction.Infrastructure},
                        new DirectionPeriod { BeginDate = new DateTime(2016, 03, 21), DefaultDirection = Direction.ObConnection},
                    }},
                new RoundDancePeople { Name = "����� �����������", Email = "paul@skbkontur.ru",
                    WorkPeriods = new List<DirectionPeriod>
                    {
                        new DirectionPeriod { BeginDate = new DateTime(2015, 04, 06), DefaultDirection = Direction.ProductBilling},
                        new DirectionPeriod { BeginDate = new DateTime(2015, 05, 25), DefaultDirection = Direction.ProductBilling },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 07, 12), DefaultDirection = Direction.Crm, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 07, 20), DefaultDirection = Direction.Support, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 07, 27), DefaultDirection = Direction.Infrastructure, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 08, 10), DefaultDirection = Direction.Duty, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 08, 17), DefaultDirection = Direction.Infrastructure, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 08, 24), DefaultDirection = Direction.SpeedyFeatures, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 09, 14), DefaultDirection = Direction.SpeedyFeatures, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 09, 21), DefaultDirection = Direction.Duty, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 09, 28), DefaultDirection = Direction.SpeedyFeatures, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 10, 12), DefaultDirection = Direction.Infrastructure, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 10, 19), DefaultDirection = Direction.RomingDiadoc, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 12, 07), DefaultDirection = Direction.Duty, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 12, 14), DefaultDirection = Direction.SpeedyFeatures, },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 01, 25), DefaultDirection = Direction.Duty, },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 02, 01), DefaultDirection = Direction.SpeedyFeatures, PairName = "��������" },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 03, 21), DefaultDirection = Direction.Infrastructure, PairName = "�����" },
                    }},
                new RoundDancePeople { Name = "��� �����", Email = "dimov@skbkontur.ru",
                    WorkPeriods = new List<DirectionPeriod>
                    {
                        new DirectionPeriod { BeginDate = new DateTime(2016, 03, 21), DefaultDirection = Direction.Infrastructure },
                    }},
                new RoundDancePeople { Name = "������ ��������", Email = "burlakov.nick@skbkontur.ru",
                    WorkPeriods = new List<DirectionPeriod>
                    {
                        new DirectionPeriod { BeginDate = new DateTime(2015, 04, 04), DefaultDirection = Direction.ProductBilling,   },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 04, 26), DefaultDirection = Direction.Support,  },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 05, 04), DefaultDirection = Direction.ProductBilling,  },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 05, 11), DefaultDirection = Direction.Support,  },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 05, 18), DefaultDirection = Direction.ProductBilling, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 08, 10), DefaultDirection = Direction.Infrastructure, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 08, 17), DefaultDirection = Direction.Duty, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 08, 24), DefaultDirection = Direction.ProlongationScenario, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 09, 14), DefaultDirection = Direction.Leave, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 09, 28), DefaultDirection = Direction.Duty, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 10, 05), DefaultDirection = Direction.SpeedyFeatures, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 10, 12), DefaultDirection = Direction.Infrastructure, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 11, 02), DefaultDirection = Direction.Duty, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 11, 10), DefaultDirection = Direction.SpeedyFeatures, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 11, 23), DefaultDirection = Direction.Fisics, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 12, 10), DefaultDirection = Direction.Certificates, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 12, 18), DefaultDirection = Direction.Leave, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 12, 21), DefaultDirection = Direction.Certificates, },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 01, 12), DefaultDirection = Direction.SpeedyFeatures, },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 01, 13), DefaultDirection = Direction.Infrastructure, },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 01, 25), DefaultDirection = Direction.Duty, },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 02, 08), DefaultDirection = Direction.Leave, },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 02, 15), DefaultDirection = Direction.SpeedyFeatures, },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 03, 21), DefaultDirection = Direction.Duty, },
                    }},
                new RoundDancePeople { Name = "������ �������", Email = "murashov_sv@skbkontur.ru",
                    WorkPeriods = new List<DirectionPeriod>
                    {
                        new DirectionPeriod { BeginDate = new DateTime(2015, 10, 20), DefaultDirection = Direction.Infrastructure,},
                        new DirectionPeriod { BeginDate = new DateTime(2015, 11, 06), DefaultDirection = Direction.SpeedyFeatures,},
                        new DirectionPeriod { BeginDate = new DateTime(2015, 11, 30), DefaultDirection = Direction.Duty,},
                        new DirectionPeriod { BeginDate = new DateTime(2015, 12, 14), DefaultDirection = Direction.SpeedyFeatures,},
                        new DirectionPeriod { BeginDate = new DateTime(2016, 01, 19), DefaultDirection = Direction.Infrastructure },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 02, 08), DefaultDirection = Direction.Duty },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 02, 15), DefaultDirection = Direction.SpeedyFeatures },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 03, 21), DefaultDirection = Direction.ModifierBuy},
                    }},
                new RoundDancePeople { Name = "����� �����", Email = "i.mamay@skbkontur.ru",
                    WorkPeriods = new List<DirectionPeriod>
                    {
                        new DirectionPeriod { BeginDate = new DateTime(2015, 08, 10), DefaultDirection = Direction.Infrastructure, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 08, 17), DefaultDirection = Direction.Duty, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 08, 24), DefaultDirection = Direction.SpeedyFeatures, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 08, 31), DefaultDirection = Direction.LinksDeliveryAgent, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 09, 28), DefaultDirection = Direction.Duty, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 10, 12), DefaultDirection = Direction.SpeedyFeatures, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 10, 29), DefaultDirection = Direction.Fisics, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 11, 24), DefaultDirection = Direction.Leave, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 12, 08), DefaultDirection = Direction.SpeedyFeatures, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 12, 14), DefaultDirection = Direction.Sickness, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 12, 21), DefaultDirection = Direction.Duty, },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 01, 11), DefaultDirection = Direction.SpeedyFeatures, },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 01, 12), DefaultDirection = Direction.Infrastructure, },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 01, 14), DefaultDirection = Direction.SpeedyFeatures, PairName = "������" },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 02, 10), DefaultDirection = Direction.BillDetalization, PairName = "������" },
                    }},
                new RoundDancePeople { Name = "���� ������", Email = "a.ivanov@skbkontur.ru",
                    WorkPeriods = new List<DirectionPeriod>
                    {
                        new DirectionPeriod { BeginDate = new DateTime(2015, 04, 06), DefaultDirection = Direction.ProductBilling, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 05, 25), DefaultDirection = Direction.ProductBilling, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 06, 02), DefaultDirection = Direction.Support,  },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 07, 06), DefaultDirection = Direction.ProductBilling, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 08, 24), DefaultDirection = Direction.Duty,  },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 09, 02), DefaultDirection = Direction.Infrastructure, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 09, 16), DefaultDirection = Direction.SpeedyFeatures, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 10, 05), DefaultDirection = Direction.Duty, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 10, 19), DefaultDirection = Direction.SpeedyFeatures},
                        new DirectionPeriod { BeginDate = new DateTime(2015, 11, 17), DefaultDirection = Direction.Duty},
                        new DirectionPeriod { BeginDate = new DateTime(2015, 11, 23), DefaultDirection = Direction.SpeedyFeatures},
                        new DirectionPeriod { BeginDate = new DateTime(2015, 12, 21), DefaultDirection = Direction.Leave},
                        new DirectionPeriod { BeginDate = new DateTime(2016, 01, 11), DefaultDirection = Direction.Duty},
                        new DirectionPeriod { BeginDate = new DateTime(2016, 01, 18), DefaultDirection = Direction.SpeedyFeatures},
                        new DirectionPeriod { BeginDate = new DateTime(2016, 02, 10), DefaultDirection = Direction.BillDetalization },
                    }},
                new RoundDancePeople { Name = "���� ������", Email = "johneg@skbkontur.ru",
                    WorkPeriods = new List<DirectionPeriod>
                    {
                        new DirectionPeriod { BeginDate = new DateTime(2015, 04, 06), DefaultDirection = Direction.Support, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 06, 02), DefaultDirection = Direction.Crm,  },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 06, 10), DefaultDirection = Direction.Support,  },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 07, 13), DefaultDirection = Direction.�aServices, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 08, 17), DefaultDirection = Direction.Leave, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 09, 07), DefaultDirection = Direction.Duty, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 09, 14), DefaultDirection = Direction.SpeedyFeatures},
                        new DirectionPeriod { BeginDate = new DateTime(2015, 11, 10), DefaultDirection = Direction.Duty},
                        new DirectionPeriod { BeginDate = new DateTime(2015, 11, 18), DefaultDirection = Direction.SpeedyFeatures},
                        new DirectionPeriod { BeginDate = new DateTime(2015, 11, 30), DefaultDirection = Direction.Certificates},
                        new DirectionPeriod { BeginDate = new DateTime(2015, 12, 28), DefaultDirection = Direction.Leave},
                        new DirectionPeriod { BeginDate = new DateTime(2016, 01, 12), DefaultDirection = Direction.Duty},
                        new DirectionPeriod { BeginDate = new DateTime(2016, 01, 18), DefaultDirection = Direction.SpeedyFeatures},
                        new DirectionPeriod { BeginDate = new DateTime(2016, 01, 25), DefaultDirection = Direction.Infrastructure, PairName = "�����" },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 02, 15), DefaultDirection = Direction.Duty },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 02, 24), DefaultDirection = Direction.Infrastructure },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 03, 09), DefaultDirection = Direction.SpeedyFeatures},
                        new DirectionPeriod { BeginDate = new DateTime(2016, 03, 21), DefaultDirection = Direction.Duty},
                        new DirectionPeriod { BeginDate = new DateTime(2016, 03, 23), DefaultDirection = Direction.SpeedyFeatures},
                    }},
                new RoundDancePeople { Name = "����� ����", Email = "anton.ezhov@skbkontur.ru",
                    WorkPeriods = new List<DirectionPeriod>
                    {
                        new DirectionPeriod { BeginDate = new DateTime(2015, 04, 06), DefaultDirection = Direction.Support,  },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 07, 06), DefaultDirection = Direction.�aServices, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 08, 16), DefaultDirection = Direction.CaTariffsAndDiscounts, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 09, 01), DefaultDirection = Direction.Leave, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 09, 18), DefaultDirection = Direction.SpeedyFeatures, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 10, 28), DefaultDirection = Direction.Fop},
                        new DirectionPeriod { BeginDate = new DateTime(2015, 11, 10), DefaultDirection = Direction.Duty},
                        new DirectionPeriod { BeginDate = new DateTime(2015, 11, 23), DefaultDirection = Direction.SpeedyFeatures},
                        new DirectionPeriod { BeginDate = new DateTime(2016, 01, 18), DefaultDirection = Direction.Duty},
                        new DirectionPeriod { BeginDate = new DateTime(2016, 01, 25), DefaultDirection = Direction.SpeedyFeatures, },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 02, 08), DefaultDirection = Direction.Infrastructure, PairName = "���������" },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 02, 24), DefaultDirection = Direction.Duty },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 03, 09), DefaultDirection = Direction.SpeedyFeatures, PairName = "������"},
                        new DirectionPeriod { BeginDate = new DateTime(2016, 03, 21), DefaultDirection = Direction.Leave},
                        new DirectionPeriod { BeginDate = new DateTime(2016, 03, 28), DefaultDirection = Direction.SpeedyFeatures},
                    }},
                new RoundDancePeople { Name = "������ �����", Email = "shalin@skbkontur.ru",
                    WorkPeriods = new List<DirectionPeriod>
                    {
                        new DirectionPeriod { BeginDate = new DateTime(2015, 04, 06), DefaultDirection = Direction.ProductBilling, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 04, 27), DefaultDirection = Direction.Support, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 06, 02), DefaultDirection = Direction.Crm,  },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 06, 20), DefaultDirection = Direction.Infrastructure,  },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 07, 01), DefaultDirection = Direction.Support, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 07, 20), DefaultDirection = Direction.Leave, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 08, 03), DefaultDirection = Direction.Duty, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 08, 10), DefaultDirection = Direction.Support, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 08, 20), DefaultDirection = Direction.Vendors, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 09, 08), DefaultDirection = Direction.RomingDiadoc, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 09, 21), DefaultDirection = Direction.CaMigration, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 10, 05), DefaultDirection = Direction.Infrastructure, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 10, 19), DefaultDirection = Direction.SpeedyFeatures, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 10, 26), DefaultDirection = Direction.Duty,  },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 11, 03), DefaultDirection = Direction.SpeedyFeatures},
                        new DirectionPeriod { BeginDate = new DateTime(2015, 11, 23), DefaultDirection = Direction.Duty},
                        new DirectionPeriod { BeginDate = new DateTime(2015, 11, 30), DefaultDirection = Direction.SpeedyFeatures},
                        new DirectionPeriod { BeginDate = new DateTime(2016, 01, 18), DefaultDirection = Direction.Duty},
                        new DirectionPeriod { BeginDate = new DateTime(2016, 01, 25), DefaultDirection = Direction.SpeedyFeatures },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 02, 01), DefaultDirection = Direction.Infrastructure, },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 02, 16), DefaultDirection = Direction.SpeedyFeatures, },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 03, 09), DefaultDirection = Direction.Duty, },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 03, 21), DefaultDirection = Direction.ObConnection},
                    }},
                // DefaultDirection = CaServices
                new RoundDancePeople { Name = "���� ���������", Email = "chicherskiy@skbkontur.ru",
                    WorkPeriods = new List<DirectionPeriod>
                    {
                        new DirectionPeriod { BeginDate = new DateTime(2015, 04, 06), DefaultDirection = Direction.�aServices, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 07, 13), DefaultDirection = Direction.Leave, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 07, 27), DefaultDirection = Direction.Duty, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 08, 10), DefaultDirection = Direction.ProductBilling, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 08, 24), DefaultDirection = Direction.SpeedyFeatures, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 08, 31), DefaultDirection = Direction.LinksDeliveryAgent, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 09, 28), DefaultDirection = Direction.Infrastructure, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 10, 10), DefaultDirection = Direction.Duty,  },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 10, 26), DefaultDirection = Direction.SpeedyFeatures, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 11, 03), DefaultDirection = Direction.Infrastructure},
                        new DirectionPeriod { BeginDate = new DateTime(2015, 12, 01), DefaultDirection = Direction.Leave},
                        new DirectionPeriod { BeginDate = new DateTime(2015, 12, 14), DefaultDirection = Direction.Certificates},
                        new DirectionPeriod { BeginDate = new DateTime(2016, 02, 08), DefaultDirection = Direction.Infrastructure},
                        new DirectionPeriod { BeginDate = new DateTime(2016, 02, 10), DefaultDirection = Direction.Leave},
                        new DirectionPeriod { BeginDate = new DateTime(2016, 02, 18), DefaultDirection = Direction.Infrastructure},
                        new DirectionPeriod { BeginDate = new DateTime(2016, 02, 19), DefaultDirection = Direction.SpeedyFeatures},
                        new DirectionPeriod { BeginDate = new DateTime(2016, 02, 24), DefaultDirection = Direction.Duty},
                        new DirectionPeriod { BeginDate = new DateTime(2016, 03, 09), DefaultDirection = Direction.SpeedyFeatures},
                    }},
                new RoundDancePeople { Name = "��� ������", Email = "suslov_yura@skbkontur.ru",
                    WorkPeriods = new List<DirectionPeriod>
                    {
                        new DirectionPeriod { BeginDate = new DateTime(2015, 04, 06), DefaultDirection = Direction.�aServices, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 06, 30), DefaultDirection = Direction.Crm, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 08, 24), DefaultDirection = Direction.ProlongationScenario, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 10, 12), DefaultDirection = Direction.Duty, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 10, 26), DefaultDirection = Direction.SpeedyFeatures, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 11, 30), DefaultDirection = Direction.Duty, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 12, 07), DefaultDirection = Direction.SpeedyFeatures, },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 02, 01), DefaultDirection = Direction.Duty, },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 02, 08), DefaultDirection = Direction.SpeedyFeatures},
                        new DirectionPeriod { BeginDate = new DateTime(2016, 02, 16), DefaultDirection = Direction.Infrastructure},
                        new DirectionPeriod { BeginDate = new DateTime(2016, 02, 19), DefaultDirection = Direction.SpeedyFeatures},
                        new DirectionPeriod { BeginDate = new DateTime(2016, 03, 09), DefaultDirection = Direction.Duty, },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 03, 21), DefaultDirection = Direction.ModifierBuy},
                    }},
                new RoundDancePeople { Name = "���� �������", Email = "a.kulikov@skbkontur.ru",
                    WorkPeriods = new List<DirectionPeriod>
                    {
                        new DirectionPeriod { BeginDate = new DateTime(2015, 07, 01), DefaultDirection = Direction.�aServices, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 08, 19), DefaultDirection = Direction.SpeedyFeatures, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 09, 21), DefaultDirection = Direction.Duty, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 09, 28), DefaultDirection = Direction.Infrastructure, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 10, 05), DefaultDirection = Direction.SpeedyFeatures, },
                        new DirectionPeriod { BeginDate = new DateTime(2015, 10, 28), DefaultDirection = Direction.Fop},
                        new DirectionPeriod { BeginDate = new DateTime(2015, 11, 23), DefaultDirection = Direction.Duty},
                        new DirectionPeriod { BeginDate = new DateTime(2015, 11, 30), DefaultDirection = Direction.SpeedyFeatures},
                        new DirectionPeriod { BeginDate = new DateTime(2015, 12, 21), DefaultDirection = Direction.Duty},
                        new DirectionPeriod { BeginDate = new DateTime(2016, 01, 11), DefaultDirection = Direction.SpeedyFeatures},
                        new DirectionPeriod { BeginDate = new DateTime(2016, 01, 18), DefaultDirection = Direction.Infrastructure },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 01, 25), DefaultDirection = Direction.Leave, },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 02, 01), DefaultDirection = Direction.SpeedyFeatures, },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 02, 15), DefaultDirection = Direction.Duty, },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 02, 24), DefaultDirection = Direction.Infrastructure, },
                        new DirectionPeriod { BeginDate = new DateTime(2016, 03, 09), DefaultDirection = Direction.SpeedyFeatures},
                        new DirectionPeriod { BeginDate = new DateTime(2016, 03, 23), DefaultDirection = Direction.Duty},
                    }},
                new RoundDancePeople { Name = "������ ������", Email = "ikp@skbkontur.ru",
                    WorkPeriods = new List<DirectionPeriod>
                    {
                        new DirectionPeriod { BeginDate = new DateTime(2016, 03, 09), DefaultDirection = Direction.Infrastructure},
                        new DirectionPeriod { BeginDate = new DateTime(2016, 03, 21), DefaultDirection = Direction.Duty},
                        new DirectionPeriod { BeginDate = new DateTime(2016, 03, 23), DefaultDirection = Direction.SpeedyFeatures},
                    }},
            };
#endregion
        }

        private Dictionary<string, RoundDancePeople> GetCachedPeoples()
        {
            return cachedFileStorage.Find<Dictionary<string, RoundDancePeople>>(FileName);
        }

        private RoundDancePeople[] GetStartVariant()
        {
            var dancePeoples = startVariant;

            foreach (var people in dancePeoples)
            {
                DirectionPeriod lastPeriod = null;
                foreach (var period in people.WorkPeriods)
                {
                    if (lastPeriod != null)
                    {
                        if (lastPeriod.BeginDate >= period.BeginDate)
                        {
                            throw new ArgumentOutOfRangeException(String.Format("period is bad for {0}", people.Name));
                        }

                        lastPeriod.SetNextPeriod(period);
                    }
                    
                    lastPeriod = period;
                }

                people.WorkPeriods.Last().SetAsCurrentPeriod();
            }

            return dancePeoples;
        }

        public RoundDancePeople[] GetAll()
        {
            peoples = peoples ?? GetCachedPeoples() ?? GetStartVariant().ToDictionary(x => x.Name, StringComparer.OrdinalIgnoreCase);
            return peoples.Select(x => x.Value).ToArray();
        }

        public void AddNew(string name, string direction, DateTime beginDate, string email = null, string pairName = null)
        {
            if (!peoples.ContainsKey(name))
            {
                peoples.Add(name, new RoundDancePeople
                                    {
                                        Name = name, Email = email, WorkPeriods = new List<DirectionPeriod>
                                        {
                                            new DirectionPeriod { Direction = direction, BeginDate = beginDate, PairName = pairName }
                                        }
                                    });
            }
            else if (!peoples[name].WorkPeriods.Any(x => x.Direction == direction && x.BeginDate == beginDate))
            {
                peoples[name].WorkPeriods.Add(new DirectionPeriod
                {
                    Direction = direction,
                    BeginDate = beginDate,
                    PairName = pairName
                });
            }
            else
            {
                return;
            }

            cachedFileStorage.Write(FileName, peoples);
        }

        public void Delete(string name, string direction, DateTime beginDate)
        {
            if (!peoples.ContainsKey(name) || !peoples[name].WorkPeriods.Any(x => x.Direction == direction && x.BeginDate.Date == beginDate.Date))
            {
                return;
            }

            peoples[name].WorkPeriods.RemoveAll(x => x.BeginDate == beginDate && x.Direction == direction);
            cachedFileStorage.Write(FileName, peoples);
        }
    }
}