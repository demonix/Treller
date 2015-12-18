using System.ComponentModel;

namespace SKBKontur.Treller.WebApplication.Controllers.RoundDance
{
    public enum Direction
    {
        [Description("�������")]
        ProductBilling = 0,

        [Description("��")]
        Support,

        [Description("��")]
        �aServices,

        [Description("���������")]
        Crm,

        [Description("��������������")]
        Infrastructure,

        [Description("������")]
        Leave,

        [Description("�������")]
        Sickness,

        [Description("���������")]
        Duty,

        [Description("������� ������")]
        SpeedyFeatures,

        [Description("������ � ������ ��")]
        CaTariffsAndDiscounts,

        [Description("�������")]
        Vendors,

        [Description("�������� ���������")]
        ProlongationScenario,

        [Description("����� �-������")]
        LinksDeliveryAgent,

        [Description("�������� ��")]
        CaMigration,

        [Description("������� ��")]
        RomingDiadoc,

        [Description("������")]
        Fisics,

        [Description("Fop")]
        Fop,

        [Description("�����������")]
        Certificates,
    }
}