import {Component, Injector, OnInit} from '@angular/core';
import {AppComponentBase} from '@shared/app-component-base';
import {
    Router,
    RouterEvent,
    NavigationEnd,
    PRIMARY_OUTLET
} from '@angular/router';
import {BehaviorSubject} from 'rxjs';
import {filter} from 'rxjs/operators';
import {MenuItem} from '@shared/layout/menu-item';

@Component({
    selector: 'sidebar-menu',
    templateUrl: './sidebar-menu.component.html'
})
export class SidebarMenuComponent extends AppComponentBase implements OnInit {
    menuItems: MenuItem[];
    menuItemsMap: { [key: number]: MenuItem } = {};
    activatedMenuItems: MenuItem[] = [];
    routerEvents: BehaviorSubject<RouterEvent> = new BehaviorSubject(undefined);
    homeRoute = '/app/about';

    constructor(injector: Injector, private router: Router) {
        super(injector);
        this.router.events.subscribe(this.routerEvents);
    }

    ngOnInit(): void {
        this.menuItems = this.getMenuItems();
        this.patchMenuItems(this.menuItems);
        this.routerEvents
            .pipe(filter((event) => event instanceof NavigationEnd))
            .subscribe((event) => {
                const currentUrl = event.url !== '/' ? event.url : this.homeRoute;
                const primaryUrlSegmentGroup = this.router.parseUrl(currentUrl).root
                    .children[PRIMARY_OUTLET];
                if (primaryUrlSegmentGroup) {
                    this.activateMenuItems('/' + primaryUrlSegmentGroup.toString());
                }
            });
    }

    getMenuItems(): MenuItem[] {
        return [
            //new MenuItem(this.l('About'), '/app/about', 'fas fa-info-circle'),
            //new MenuItem(this.l('HomePage'), '/app/home', 'fas fa-home'),
            
            new MenuItem(this.l('HỆ THỐNG'), '', 'fas fa-cog', 'Pages.HeThong', [
                new MenuItem(
                    this.l('PHÂN QUYỀN'),
                    '/app/roles',
                    'fas fa-theater-masks',
                    'Pages.Roles'
                ),
                new MenuItem(
                    this.l('THAM SỐ'),
                    '/app/cauhinhthamso',
                    'fas fa-cog',
                    'Pages.Roles'
                ),
                new MenuItem(
                    this.l('NGƯỜI DÙNG'),
                    '/app/users',
                    'fas fa-users',
                    'Pages.Users'
                ),
               
               ]),
            new MenuItem('DANH MỤC', '', 'fas fa-align-justify', 'Pages.DanhMuc', [
                new MenuItem(
                    this.l('TỈNH'),
                    '/app/tenants',
                    'fas fa-building',
                    'Pages.Tenants'
                ),
            ]),   
            new MenuItem('GIÁM SÁT', '', 'fas fa-desktop', 'GIAMSAT', [
                new MenuItem('HOME PAGE', '/app/', 'fas fa-home', 'GIAMSAT.HOMEPAGE'),
                new MenuItem('BĂNG RỘNG','','fas fa-ethernet','GIAMSAT.BANGRONG',[
                    new MenuItem('OLT','','fas fa-circle','GIAMSAT.BANGRONG.OLT',[
                        new MenuItem(this.l('ALARM'),'/app/','fa fa-bell','GIAMSAT.BANGRONG.OLT.ALARM'),
                        new MenuItem(this.l('TRAFFIC'), '/app/', 'fas fa-traffic-light', 'GIAMSAT.BANGRONG.OLT.TRAFFIC'),
                    ]),
                    new MenuItem(this.l('SWITCH L2'), '','fas fa-network-wired', 'GIAMSAT.BANGRONG.L2SW',[
                        new MenuItem(this.l('ALARM'),'app','fa fa-bell', 'GIAMSAT.BANGRONG.L2SW.ALARM'),
                        new MenuItem( this.l('TRAFFIC'),  'app','fas fa-traffic-light','GIAMSAT.BANGRONG.L2SW.TRAFFIC'),
                    ]),
                    new MenuItem( this.l('MANE'),'', 'fas fa-chart-line', 'GIAMSAT.BANGRONG.MANE',[
                        new MenuItem( this.l('ALARM'), 'app', 'fa fa-bell', 'GIAMSAT.BANGRONG.MANE.ALARM'),
                        new MenuItem(this.l('TRAFFIC'),'app','fas fa-traffic-light', 'GIAMSAT.BANGRONG.MANE.TRAFFIC'),
                    ]),
                    new MenuItem(this.l('BRAS'), '', 'fas fa-server', 'GIAMSAT.BANGRONG.BRAS',[
                        new MenuItem( this.l('ALARM'), 'app', 'fa fa-bell', 'GIAMSAT.BANGRONG.BRAS.ALARM'),
                        new MenuItem(this.l('TRAFFIC'),'app','fas fa-traffic-light','GIAMSAT.BANGRONG.BRAS.TRAFFIC'),
                    ]),
                ]),
                new MenuItem('PSTN', '/app/', 'fas fa-phone', 'GIAMSAT.PSTN'),
                new MenuItem('VÔ TUYÊN',  '/app/', 'fas fa-wifi', 'GIAMSAT.VOTUYEN', [
                    new MenuItem('BAD CELL','/app/badcell','fas fa-building','Pages.BadCell'),
                    new MenuItem('TRẠM LOẠI TRỪ','/app/tramloaitru','fas fa-ban','Pages.TramLoaiTru'),
                ]),
                new MenuItem('TRUYỀN DẪN', '/app/', 'fas fa-exchange-alt','GIAMSAT.TRUYENDAN'),
                new MenuItem('IOT', '/app/','fas fa-robot','GIAMSAT.IOT'),
            ]),
            new MenuItem('QUẢN LÝ TÀI NGUYÊN', '', 'fas fa-tasks', 'QLTN', [
                new MenuItem('BĂNG RỘNG','','fas fa-ethernet','QLTN.BANGRONG',[
                    new MenuItem('OLT','/app/','fas fa-circle','QLTN.BANGRONG.OLT'),
                    new MenuItem(this.l('SWITCH L2'), 'app','fas fa-network-wired', 'QLTN.BANGRONG.L2SW'),
                    new MenuItem( this.l('MANE'),'app', 'fas fa-chart-line', 'QLTN.BANGRONG.MANE'),
                    new MenuItem(this.l('BRAS'), 'app', 'fas fa-server', 'QLTN.BANGRONG.BRAS'),
                ]),
                new MenuItem('PSTN', '/app/', 'fas fa-phone', 'QLTN.PSTN'),
                new MenuItem('VÔ TUYÊN',  '/app/', 'fas fa-wifi', 'QLTN.VOTUYEN'),
                new MenuItem('TRUYỀN DẪN', '/app/', 'fas fa-exchange-alt','QLTN.TRUYENDAN'),
                new MenuItem('IOT', '/app/','fas fa-robot','QLTN.IOT'),
            ]),
            new MenuItem('BÁO CÁO', '', 'fas fa-clipboard', 'BAOCAO', [
                new MenuItem('HOME PAGE', '/app/', 'fas fa-home', 'BAOCAO.HOMEPAGE'),
                new MenuItem('BĂNG RỘNG','','fas fa-ethernet','BAOCAO.BANGRONG'),
                new MenuItem('PSTN', '/app/', 'fas fa-phone', 'BAOCAO.PSTN'),
                new MenuItem('VÔ TUYÊN',  '/app/', 'fas fa-wifi', 'BAOCAO.VOTUYEN'),
                new MenuItem('TRUYỀN DẪN', '/app/', 'fas fa-exchange-alt','BAOCAO.TRUYENDAN'),
                new MenuItem('IOT', '/app/','fas fa-robot','BAOCAO.IOT'),
            ]),
            new MenuItem('ĐO KIỂM CHẤT LƯỢNG', '', 'fas fa-chess', 'DKCL', [
                new MenuItem('BĂNG RỘNG','','fas fa-ethernet','DKCL.BANGRONG',[
                    new MenuItem('OLT','/app/','fas fa-circle','DKCL.BANGRONG.OLT'),
                    new MenuItem(this.l('SWITCH L2'), '/app/','fas fa-network-wired', 'DKCL.BANGRONG.L2SW'),
                    new MenuItem( this.l('MANE'),'/app/', 'fas fa-chart-line', 'DKCL.BANGRONG.MANE'),
                    new MenuItem(this.l('BRAS'), '/app/', 'fas fa-server', 'DKCL.BANGRONG.BRAS'),
                ]),
                new MenuItem('PSTN', '/app/', 'fas fa-phone', 'DKCL.PSTN'),
                new MenuItem('VÔ TUYÊN',  '/app/', 'fas fa-wifi', 'DKCL.VOTUYEN'),
                new MenuItem('TRUYỀN DẪN', '/app/', 'fas fa-exchange-alt','DKCL.TRUYENDAN'),
                new MenuItem('IOT', '/app/','fas fa-robot','DKCL.IOT'),
            ]),
            new MenuItem('BẢO DƯỠNG', '', 'fas fa-tools', 'BAODUONG', [
                new MenuItem('BĂNG RỘNG','','fas fa-ethernet','BAODUONG.BANGRONG'),
                new MenuItem('PSTN', '/app/', 'fas fa-phone', 'BAODUONG.PSTN'),
                new MenuItem('VÔ TUYÊN',  '/app/', 'fas fa-wifi', 'BAODUONG.VOTUYEN'),
                new MenuItem('TRUYỀN DẪN', '/app/', 'fas fa-exchange-alt','BAODUONG.TRUYENDAN'),
                new MenuItem('IOT', '/app/','fas fa-robot','BAODUONG.IOT'),
            ]),
        ];
    }

    patchMenuItems(items: MenuItem[], parentId?: number): void {
        items.forEach((item: MenuItem, index: number) => {
            item.id = parentId ? Number(parentId + '' + (index + 1)) : index + 1;
            if (parentId) {
                item.parentId = parentId;
            }
            if (parentId || item.children) {
                this.menuItemsMap[item.id] = item;
            }
            if (item.children) {
                this.patchMenuItems(item.children, item.id);
            }
        });
    }

    activateMenuItems(url: string): void {
        this.deactivateMenuItems(this.menuItems);
        this.activatedMenuItems = [];
        const foundedItems = this.findMenuItemsByUrl(url, this.menuItems);
        foundedItems.forEach((item) => {
            this.activateMenuItem(item);
        });
    }

    deactivateMenuItems(items: MenuItem[]): void {
        items.forEach((item: MenuItem) => {
            item.isActive = false;
            item.isCollapsed = true;
            if (item.children) {
                this.deactivateMenuItems(item.children);
            }
        });
    }

    findMenuItemsByUrl(
        url: string,
        items: MenuItem[],
        foundedItems: MenuItem[] = []
    ): MenuItem[] {
        items.forEach((item: MenuItem) => {
            if (item.route === url) {
                foundedItems.push(item);
            } else if (item.children) {
                this.findMenuItemsByUrl(url, item.children, foundedItems);
            }
        });
        return foundedItems;
    }

    activateMenuItem(item: MenuItem): void {
        item.isActive = true;
        if (item.children) {
            item.isCollapsed = false;
        }
        this.activatedMenuItems.push(item);
        if (item.parentId) {
            this.activateMenuItem(this.menuItemsMap[item.parentId]);
        }
    }

    isMenuItemVisible(item: MenuItem): boolean {
        if (!item.permissionName) {
            return true;
        }
        return this.permission.isGranted(item.permissionName);
    }
}
