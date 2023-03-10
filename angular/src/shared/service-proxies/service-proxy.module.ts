import { NgModule } from '@angular/core';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AbpHttpInterceptor } from 'abp-ng2-module';

import * as ApiServiceProxies from './service-proxies';
import * as TestServiceProxies from '../../app/test/test.service';
import * as UploadFileServiceProxies from '../../app/log/uploadfile.service';
import * as DienNangServiceProxies from '../../app/diennang/diennang.service';
import * as CauHinhServiceProxies from '../../app/cauhinh/cauhinh.service';
import * as BadCellServiceProxies from '../../app/badcell/badcell.service';
import * as TramLoaiTruServiceProxies from '../../app/tramloaitru/tramloaitru.service';

@NgModule({
    providers: [
        ApiServiceProxies.RoleServiceProxy,
        ApiServiceProxies.SessionServiceProxy,
        ApiServiceProxies.TenantServiceProxy,
        ApiServiceProxies.UserServiceProxy,
        ApiServiceProxies.TokenAuthServiceProxy,
        ApiServiceProxies.AccountServiceProxy,
        ApiServiceProxies.ConfigurationServiceProxy,
        TestServiceProxies.TestServiceProxy,
        UploadFileServiceProxies.UploadFileServiceProxy,
        DienNangServiceProxies.DienNangServiceProxy,
        CauHinhServiceProxies.CauHinhServiceProxy,
        BadCellServiceProxies.BadCellServiceProxy,
        TramLoaiTruServiceProxies.TramLoaiTruServiceProxy,
        { provide: HTTP_INTERCEPTORS, useClass: AbpHttpInterceptor, multi: true }
    ]
})
export class ServiceProxyModule { }
