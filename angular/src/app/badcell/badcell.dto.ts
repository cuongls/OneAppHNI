import * as moment from 'moment';
export class BadCellDto implements BadCellDto {
    id: number;
    
    matinh: string;
    donvi: string;
    quanhuyen: string;
    tentram: string;
    tencell: string;
    cellid: number;
    loaicell: string;
    qosdiem: number;
    qostyle: number;
    sqichuanhoa1: number;
    sqichuanhoa2: number;
    sqichuanhoa3: number;
    sqichuanhoa4: number;
    sqichuanhoa5: number;
    sqidiem1: number;
    sqidiem2: number;
    sqidiem3: number;
    sqidiem4: number;
    sqidiem5: number;
    kpidaurasqi1: number;
    kpidaurasqi2: number;
    kpidaurasqi3: number;
    kpidaurasqi4: number;
    kpidaurasqi5: number;
    kpidauvaosqi1: number;
    kpidauvaosqi2: number;
    kpidauvaosqi3: number;
    kpidauvaosqi4: number;
    kpidauvaosqi5: number;
    kpidauvaodor: number;
    traffic: number;
    tuanbaocao: number;
    nambaocao: number;
    trangthai: number;
    tenantId: number | undefined;
    

    constructor(data?: IBadCellDto) {
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
            
            this.matinh = _data["matinh"];
            this.donvi = _data["donvi"];
            this.quanhuyen = _data["quanhuyen"];
            this.tentram = _data["tentram"];
            this.tencell = _data["tencell"];
            this.cellid = _data["cellid"];
            this.loaicell = _data["loaicell"];
            this.qosdiem = _data["qosdiem"];
            this.qostyle = _data["qostyle"];
            this.sqichuanhoa1 = _data["sqichuanhoa1"];
            this.sqichuanhoa2 = _data["sqichuanhoa2"];
            this.sqichuanhoa3 = _data["sqichuanhoa3"];
            this.sqichuanhoa4 = _data["sqichuanhoa4"];
            this.sqichuanhoa5 = _data["sqichuanhoa5"];
            this.sqidiem1 = _data["sqidiem1"];
            this.sqidiem2 = _data["sqidiem2"];
            this.sqidiem3 = _data["sqidiem3"];
            this.sqidiem4 = _data["sqidiem4"];
            this.sqidiem5 = _data["sqidiem5"];
            this.kpidaurasqi1 = _data["kpidaurasqi1"];
            this.kpidaurasqi2 = _data["kpidaurasqi2"];
            this.kpidaurasqi3 = _data["kpidaurasqi3"];
            this.kpidaurasqi4 = _data["kpidaurasqi4"];
            this.kpidaurasqi5 = _data["kpidaurasqi5"];
            this.kpidauvaosqi1 = _data["kpidauvaosqi1"];
            this.kpidauvaosqi2 = _data["kpidauvaosqi2"];
            this.kpidauvaosqi3 = _data["kpidauvaosqi3"];
            this.kpidauvaosqi4 = _data["kpidauvaosqi4"];
            this.kpidauvaosqi5 = _data["kpidauvaosqi5"];
            this.kpidauvaodor = _data["kpidauvaodor"];
            this.traffic = _data["traffic"];
            this.tuanbaocao = _data["tuanbaocao"];
            this.nambaocao = _data["nambaocao"];
            this.trangthai = _data["trangthai"];
            this.tenantId = _data["tenantId"];
            
        }
    }

    static fromJS(data: any): BadCellDto {
        data = typeof data === 'object' ? data : {};
        let result = new BadCellDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"]= this.id;
        
        data["matinh"]= this.matinh;
        data["donvi"]= this.donvi;
        data["quanhuyen"]= this.quanhuyen;
        data["tentram"]= this.tentram;
        data["tencell"]= this.tencell;
        data["cellid"]= this.cellid;
        data["loaicell"]= this.loaicell;
        data["qosdiem"]= this.qosdiem;
        data["qostyle"]= this.qostyle;
        data["sqichuanhoa1"]= this.sqichuanhoa1;
        data["sqichuanhoa2"]= this.sqichuanhoa2;
        data["sqichuanhoa3"]= this.sqichuanhoa3;
        data["sqichuanhoa4"]= this.sqichuanhoa4;
        data["sqichuanhoa5"]= this.sqichuanhoa5;
        data["sqidiem1"]= this.sqidiem1;
        data["sqidiem2"]= this.sqidiem2;
        data["sqidiem3"]= this.sqidiem3;
        data["sqidiem4"]= this.sqidiem4;
        data["sqidiem5"]= this.sqidiem5;
        data["kpidaurasqi1"]= this.kpidaurasqi1;
        data["kpidaurasqi2"]= this.kpidaurasqi2;
        data["kpidaurasqi3"]= this.kpidaurasqi3;
        data["kpidaurasqi4"]= this.kpidaurasqi4;
        data["kpidaurasqi5"]= this.kpidaurasqi5;
        data["kpidauvaosqi1"]= this.kpidauvaosqi1;
        data["kpidauvaosqi2"]= this.kpidauvaosqi2;
        data["kpidauvaosqi3"]= this.kpidauvaosqi3;
        data["kpidauvaosqi4"]= this.kpidauvaosqi4;
        data["kpidauvaosqi5"]= this.kpidauvaosqi5;
        data["kpidauvaodor"]= this.kpidauvaodor;
        data["traffic"]= this.traffic;
        data["tuanbaocao"]= this.tuanbaocao;
        data["nambaocao"]= this.nambaocao;
        data["trangthai"]= this.trangthai;

        data["tenantId"] = this.tenantId;
        return data; 
    }

    clone(): BadCellDto {
        const json = this.toJSON();
        let result = new BadCellDto();
        result.init(json);
        return result;
    }
}

export interface IBadCellDto {
    id: number;

    matinh: string;
    donvi: string;
    quanhuyen: string;
    tentram: string;
    tencell: string;
    cellid: number;
    loaicell: string;
    qosdiem: number;
    qostyle: number;
    sqichuanhoa1: number;
    sqichuanhoa2: number;
    sqichuanhoa3: number;
    sqichuanhoa4: number;
    sqichuanhoa5: number;
    sqidiem1: number;
    sqidiem2: number;
    sqidiem3: number;
    sqidiem4: number;
    sqidiem5: number;
    kpidaurasqi1: number;
    kpidaurasqi2: number;
    kpidaurasqi3: number;
    kpidaurasqi4: number;
    kpidaurasqi5: number;
    kpidauvaosqi1: number;
    kpidauvaosqi2: number;
    kpidauvaosqi3: number;
    kpidauvaosqi4: number;
    kpidauvaosqi5: number;
    kpidauvaodor: number;
    traffic: number;
    tuanbaocao: number;
    nambaocao: number;
    trangthai:  number;
    tenantId: number | undefined;
    
}
export class BadCellDtoPagedResultDto implements IBadCellDtoPagedResultDto {
    items: BadCellDto[] | undefined;
    totalCount: number;

    constructor(data?: IBadCellDtoPagedResultDto) {
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
                    this.items.push(BadCellDto.fromJS(item));
            }
            this.totalCount = _data["totalCount"];
        }
    }

    static fromJS(data: any): BadCellDtoPagedResultDto {
        data = typeof data === 'object' ? data : {};
        let result = new BadCellDtoPagedResultDto();
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

    clone(): BadCellDtoPagedResultDto {
        const json = this.toJSON();
        let result = new BadCellDtoPagedResultDto();
        result.init(json);
        return result;
    }
}
export interface IBadCellDtoPagedResultDto {
    items: BadCellDto[] | undefined;
    totalCount: number;
}
