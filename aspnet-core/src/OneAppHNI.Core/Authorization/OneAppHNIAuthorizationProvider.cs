using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace OneAppHNI.Authorization
{
    public class OneAppHNIAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_DienNang, L("DienNang"));
            context.CreatePermission(PermissionNames.Pages_DanhMuc, L("DanhMuc"));
            context.CreatePermission(PermissionNames.Pages_HeThong, L("HeThong"));
            context.CreatePermission(PermissionNames.Pages_VoTuyen, L("VoTuyen"));
            context.CreatePermission(PermissionNames.Pages_NhaTram, L("NhaTram"));
            context.CreatePermission(PermissionNames.Pages_Badcell, L("BadCell"));
            context.CreatePermission(PermissionNames.Pages_TramLoaiTru, L("TramLoaiTru"));

            context.CreatePermission(PermissionNames.GIAMSAT, L("GIAMSAT"));
            context.CreatePermission(PermissionNames.GIAMSAT_BANGRONG, L("GIAMSAT.BANGRONG"));
            context.CreatePermission(PermissionNames.GIAMSAT_BANGRONG_OLT, L("GIAMSAT.BANGRONG.OLT"));
            context.CreatePermission(PermissionNames.GIAMSAT_BANGRONG_OLT_ALARM, L("GIAMSAT.BANGRONG.OLT.ALARM"));
            context.CreatePermission(PermissionNames.GIAMSAT_BANGRONG_OLT_TRAFFIC, L("GIAMSAT.BANGRONG.OLT.TRAFFIC"));
            context.CreatePermission(PermissionNames.GIAMSAT_BANGRONG_L2SW, L("GIAMSAT.BANGRONG.L2SW"));
            context.CreatePermission(PermissionNames.GIAMSAT_BANGRONG_L2SW_ALARM, L("GIAMSAT.BANGRONG.L2SW.ALARM"));
            context.CreatePermission(PermissionNames.GIAMSAT_BANGRONG_L2SW_TRAFFIC, L("GIAMSAT.BANGRONG.L2SW.TRAFFIC"));
            context.CreatePermission(PermissionNames.GIAMSAT_BANGRONG_MANE, L("GIAMSAT.BANGRONG.MANE"));
            context.CreatePermission(PermissionNames.GIAMSAT_BANGRONG_MANE_ALARM, L("GIAMSAT.BANGRONG.MANE.ALARM"));
            context.CreatePermission(PermissionNames.GIAMSAT_BANGRONG_MANE_TRAFFIC, L("GIAMSAT.BANGRONG.MANE.TRAFFIC"));
            context.CreatePermission(PermissionNames.GIAMSAT_BANGRONG_BRAS, L("GIAMSAT.BANGRONG.BRAS"));
            context.CreatePermission(PermissionNames.GIAMSAT_BANGRONG_BRAS_ALARM, L("GIAMSAT.BANGRONG.BRAS.ALARM"));
            context.CreatePermission(PermissionNames.GIAMSAT_BANGRONG_BRAS_TRAFFIC, L("GIAMSAT.BANGRONG.BRAS.TRAFFIC"));
            context.CreatePermission(PermissionNames.GIAMSAT_PSTN, L("GIAMSAT.PSTN"));
            context.CreatePermission(PermissionNames.GIAMSAT_VOTUYEN, L("GIAMSAT.VOTUYEN"));
            context.CreatePermission(PermissionNames.GIAMSAT_TRUYENDAN, L("GIAMSAT.TRUYENDAN"));
            context.CreatePermission(PermissionNames.GIAMSAT_IOT, L("GIAMSAT.IOT"));
            context.CreatePermission(PermissionNames.BAOCAO, L("BAOCAO"));
            context.CreatePermission(PermissionNames.BAOCAO_BANGRONG, L("BAOCAO.BANGRONG"));
            context.CreatePermission(PermissionNames.BAOCAO_PSTN, L("BAOCAO.PSTN"));
            context.CreatePermission(PermissionNames.BAOCAO_VOTUYEN, L("BAOCAO.VOTUYEN"));
            context.CreatePermission(PermissionNames.BAOCAO_TRUYENDAN, L("BAOCAO.TRUYENDAN"));
            context.CreatePermission(PermissionNames.BAOCAO_IOT, L("BAOCAO.IOT"));
            context.CreatePermission(PermissionNames.QLTN, L("QLTN"));
            context.CreatePermission(PermissionNames.Q_LTN_BANGRONG, L("Q.LTN.BANGRONG"));
            context.CreatePermission(PermissionNames.QLTN_BANGRONG_OLT, L("QLTN.BANGRONG.OLT"));
            context.CreatePermission(PermissionNames.QLTN_BANGRONG_L2SW, L("QLTN.BANGRONG.L2SW"));
            context.CreatePermission(PermissionNames.QLTN_BANGRONG_MANE, L("QLTN.BANGRONG.MANE"));
            context.CreatePermission(PermissionNames.QLTN_BANGRONG_BRAS, L("QLTN.BANGRONG.BRAS"));
            context.CreatePermission(PermissionNames.QLTN_PSTN, L("QLTN.PSTN"));
            context.CreatePermission(PermissionNames.QLTN_VOTUYEN, L("QLTN.VOTUYEN"));
            context.CreatePermission(PermissionNames.QLTN_TRUYENDAN, L("QLTN.TRUYENDAN"));
            context.CreatePermission(PermissionNames.QLTN_IOT, L("QLTN.IOT"));
            context.CreatePermission(PermissionNames.DKCL, L("DKCL"));
            context.CreatePermission(PermissionNames.DKCL_BANGRONG, L("DKCL.BANGRONG"));
            context.CreatePermission(PermissionNames.DKCL_BANGRONG_OLT, L("DKCL.BANGRONG.OLT"));
            context.CreatePermission(PermissionNames.DKCL_BANGRONG_L2SW, L("DKCL.BANGRONG.L2SW"));
            context.CreatePermission(PermissionNames.DKCL_BANGRONG_MANE, L("DKCL.BANGRONG.MANE"));
            context.CreatePermission(PermissionNames.DKCL_BANGRONG_BRAS, L("DKCL.BANGRONG.BRAS"));
            context.CreatePermission(PermissionNames.DKCL_PSTN, L("DKCL.PSTN"));
            context.CreatePermission(PermissionNames.DKCL_VOTUYEN, L("DKCL.VOTUYEN"));
            context.CreatePermission(PermissionNames.DKCL_TRUYENDAN, L("DKCL.TRUYENDAN"));
            context.CreatePermission(PermissionNames.DKCL_IOT, L("DKCL.IOT"));
            context.CreatePermission(PermissionNames.BAODUONG, L("BAODUONG"));
            context.CreatePermission(PermissionNames.BAODUONG_BRCD, L("BAODUONG.BRCD"));
            context.CreatePermission(PermissionNames.BAODUONG_VOTUYEN, L("BAODUONG.VOTUYEN"));



        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, OneAppHNIConsts.LocalizationSourceName);
        }
    }
}
