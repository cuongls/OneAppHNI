import * as moment from 'moment';
export class TramLoaiTruDto implements TramLoaiTruDto {
    id: number;
    quanhuyen: string;
    latitude: number;
    longitude: number;
    loaitram: string;
    sitename: string;
    cellname: string;
    cellnamealias: string;
    trangthai: string;
    thoigian: Date;
    ghichu: string;
    tenantId: number | undefined;
    

    constructor(data?: ITramLoaiTruDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id= _data["id"];
            this.quanhuyen= _data["quanhuyen"];
            this.latitude= _data["latitude"];
            this.longitude= _data["longitude"];
            this.loaitram= _data["loaitram"];
            this.sitename= _data["sitename"];
            this.cellname= _data["cellname"];
            this.cellnamealias= _data["cellnamealias"];
            this.trangthai= _data["trangthai"];
            this.thoigian= _data["thoigian"];
            this.ghichu= _data["ghichu"];
            
            this.tenantId = _data["tenantId"];
            
        }
    }

    static fromJS(data: any): TramLoaiTruDto {
        data = typeof data === 'object' ? data : {};
        let result = new TramLoaiTruDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"]= this.id;
        data["quanhuyen"]= this.quanhuyen;
        data["latitude"]= this.latitude;
        data["longitude"]= this.longitude;
        data["loaitram"]= this.loaitram;
        data["sitename"]= this.sitename;
        data["cellname"]= this.cellname;
        data["cellnamealias"]= this.cellnamealias;
        data["trangthai"]= this.trangthai;
        data["thoigian"]= this.thoigian;
        data["ghichu"]= this.ghichu;
        
        data["tenantId"] = this.tenantId;
        return data; 
    }

    clone(): TramLoaiTruDto {
        const json = this.toJSON();
        let result = new TramLoaiTruDto();
        result.init(json);
        return result;
    }
}

export interface ITramLoaiTruDto {
    id: number;
    quanhuyen: string;
    latitude: number;
    longitude: number;
    loaitram: string;
    sitename: string;
    cellname: string;
    cellnamealias: string;
    trangthai: string;
    thoigian: Date;
    ghichu: string;
    tenantId: number | undefined;
    
}
export class TramLoaiTruDtoPagedResultDto implements ITramLoaiTruDtoPagedResultDto {
    items: TramLoaiTruDto[] | undefined;
    totalCount: number;

    constructor(data?: ITramLoaiTruDtoPagedResultDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            if (Array.isArray(_data["items"])) {
                this.items = [] as any;
                for (let item of _data["items"])
                    this.items.push(TramLoaiTruDto.fromJS(item));
            }
            this.totalCount = _data["totalCount"];
        }
    }

    static fromJS(data: any): TramLoaiTruDtoPagedResultDto {
        data = typeof data === 'object' ? data : {};
        let result = new TramLoaiTruDtoPagedResultDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        if (Array.isArray(this.items)) {
            data["items"] = [];
            for (let item of this.items)
                data["items"].push(item.toJSON());
        }
        data["totalCount"] = this.totalCount;
        return data; 
    }

    clone(): TramLoaiTruDtoPagedResultDto {
        const json = this.toJSON();
        let result = new TramLoaiTruDtoPagedResultDto();
        result.init(json);
        return result;
    }
}
export interface ITramLoaiTruDtoPagedResultDto {
    items: TramLoaiTruDto[] | undefined;
    totalCount: number;
}
