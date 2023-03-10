import * as moment from 'moment';
export class DienNangDto implements IDienNangDto {
    id: number;
    macsht: string;
    ttvt: string;
    doivt: string;
    mucdichsd: string;
    tentram: string;
    loaihinhth: string;
    sodien: number;
    tiendien: number;
    cpvanhanh: number;
    cpthuehatang: number;
    cplaodong: number;
    cpsuachua: number;
    cpkhac: number;
    mahoadon: string;
    chungcsht: string;
    ghichu: string;
    trangthai: string;
    netxxacnhan: string;
    tenantId: number | undefined;
    

    constructor(data?: IDienNangDto) {
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
            this.macsht= _data["macsht"];
            this.ttvt= _data["ttvt"];
            this.doivt= _data["doivt"];
            this.mucdichsd= _data["mucdichsd"];
            this.tentram= _data["tentram"];
            this.loaihinhth= _data["loaihinhth"];
            this.sodien= _data["sodien"];
            this.tiendien= _data["tiendien"];
            this.cpvanhanh= _data["cpvanhanh"];
            this.cpthuehatang= _data["cpthuehatang"];
            this.cplaodong= _data["cplaodong"];
            this.cpsuachua= _data["cpsuachua"];
            this.cpkhac= _data["cpkhac"];
            this.mahoadon= _data["mahoadon"];
            this.chungcsht= _data["chungcsht"];
            this.ghichu= _data["ghichu"];
            this.trangthai= _data["trangthai"];
            this.netxxacnhan= _data["netxxacnhan"];
            this.tenantId = _data["tenantId"];
            
        }
    }

    static fromJS(data: any): DienNangDto {
        data = typeof data === 'object' ? data : {};
        let result = new DienNangDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"]= this.id;
        data["macsht"]= this.macsht;
        data["ttvt"]= this.ttvt;
        data["doivt"]= this.doivt;
        data["mucdichsd"]= this.mucdichsd;
        data["tentram"]= this.tentram;
        data["loaihinhth"]= this.loaihinhth;
        data["sodien"]= this.sodien;
        data["tiendien"]= this.tiendien;
        data["cpvanhanh"]= this.cpvanhanh;
        data["cpthuehatang"]= this.cpthuehatang;
        data["cplaodong"]= this.cplaodong;
        data["cpsuachua"]= this.cpsuachua;
        data["cpkhac"]= this.cpkhac;
        data["mahoadon"]= this.mahoadon;
        data["chungcsht"]= this.chungcsht;
        data["ghichu"]= this.ghichu;
        data["trangthai"]= this.trangthai;
        data["netxxacnhan"]= this.netxxacnhan;
        data["tenantId"] = this.tenantId;
        return data; 
    }

    clone(): DienNangDto {
        const json = this.toJSON();
        let result = new DienNangDto();
        result.init(json);
        return result;
    }
}

export interface IDienNangDto {
    id: number;
    macsht: string;
    ttvt: string;
    doivt: string;
    mucdichsd: string;
    tentram: string;
    loaihinhth: string;
    sodien: number;
    tiendien: number;
    cpvanhanh: number;
    cpthuehatang: number;
    cplaodong: number;
    cpsuachua: number;
    cpkhac: number;
    mahoadon: string;
    chungcsht: string;
    ghichu: string;
    trangthai: string;
    netxxacnhan: string;
    tenantId: number | undefined;
    
}
export class DienNangDtoPagedResultDto implements IDienNangDtoPagedResultDto {
    items: DienNangDto[] | undefined;
    totalCount: number;

    constructor(data?: IDienNangDtoPagedResultDto) {
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
                    this.items.push(DienNangDto.fromJS(item));
            }
            this.totalCount = _data["totalCount"];
        }
    }

    static fromJS(data: any): DienNangDtoPagedResultDto {
        data = typeof data === 'object' ? data : {};
        let result = new DienNangDtoPagedResultDto();
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

    clone(): DienNangDtoPagedResultDto {
        const json = this.toJSON();
        let result = new DienNangDtoPagedResultDto();
        result.init(json);
        return result;
    }
}
export interface IDienNangDtoPagedResultDto {
    items: DienNangDto[] | undefined;
    totalCount: number;
}
export class CanhBaoDto implements ICanhBaoDto{
    macsht: string;
    ttvt: string;
    doivt: string;
    mucdichsd: string;
    tentram: string;
    loaihinhth: string;
    muccanhbao: string;
    sodien: number;
    sodienthangtruoc: number;
    sodiennamtruoc: number;
    ghichu: string;
    constructor(data?: ICanhBaoDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.macsht= _data["macsht"];
            this.ttvt= _data["ttvt"];
            this.doivt= _data["doivt"];
            this.mucdichsd= _data["mucdichsd"];
            this.tentram= _data["tentram"];
            this.loaihinhth= _data["loaihinhth"];
            this.muccanhbao= _data["muccanhbao"];
            this.sodien= _data["sodien"];
            this.sodienthangtruoc= _data["sodienthangtruoc"];
            this.sodiennamtruoc= _data["sodiennamtruoc"];
            this.ghichu= _data["ghichu"];
        }
    }

    static fromJS(data: any): CanhBaoDto {
        data = typeof data === 'object' ? data : {};
        let result = new CanhBaoDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["macsht"]= this.macsht;
        data["ttvt"]= this.ttvt;
        data["doivt"]= this.doivt;
        data["mucdichsd"]= this.mucdichsd;
        data["tentram"]= this.tentram;
        data["loaihinhth"]= this.loaihinhth;
        data["muccanhbao"]= this.muccanhbao;
        data["sodien"]= this.sodien;
        data["sodienthangtruoc"]= this.sodienthangtruoc;
        data["sodiennamtruoc"]= this.sodiennamtruoc;
        data["ghichu"]= this.ghichu;
        return data; 
    }

    clone(): CanhBaoDto {
        const json = this.toJSON();
        let result = new CanhBaoDto();
        result.init(json);
        return result;
    }
}

export interface ICanhBaoDto{
    macsht: string;
    ttvt: string;
    doivt: string;
    mucdichsd: string;
    tentram: string;
    loaihinhth: string;
    muccanhbao: string;
    sodien: number;
    sodienthangtruoc: number;
    sodiennamtruoc: number;
    ghichu: string;
}
export class ListCanhBaoDto implements IListCanhBaoDto {
    items: CanhBaoDto[] | undefined;

    constructor(data?: IListCanhBaoDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            if (Array.isArray(_data)) {
                this.items = [] as any;
                for (let item of _data)
                    this.items.push(CanhBaoDto.fromJS(item));
            }
        }
    }

    static fromJS(data: any): ListCanhBaoDto {
        data = typeof data === 'object' ? data : {};
        let result = new ListCanhBaoDto();
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
        return data; 
    }

    clone(): ListCanhBaoDto {
        const json = this.toJSON();
        let result = new ListCanhBaoDto();
        result.init(json);
        return result;
    }
}
export interface IListCanhBaoDto {
    items: CanhBaoDto[] | undefined;
}