import * as moment from 'moment';


export class TestDto implements ITestDto {
    id: number;
    code: string;
    name: string;
    description: string;
    tenantId: number | undefined;
    

    constructor(data?: ITestDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.code = _data["code"];
            this.name = _data["name"];
            this.description = _data["description"];
            this.tenantId = _data["tenantId"];
            
        }
    }

    static fromJS(data: any): TestDto {
        data = typeof data === 'object' ? data : {};
        let result = new TestDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["code"] = this.code;
        data["name"] = this.name;
        data["description"] = this.description;
        data["tenantId"] = this.tenantId;
        return data; 
    }

    clone(): TestDto {
        const json = this.toJSON();
        let result = new TestDto();
        result.init(json);
        return result;
    }
}

export interface ITestDto {
    id: number;
    code: string;
    name: string | undefined;
    description: string;
    tenantId: number | undefined;
    
}
export class TestDtoPagedResultDto implements ITestDtoPagedResultDto {
    items: TestDto[] | undefined;
    totalCount: number;

    constructor(data?: ITestDtoPagedResultDto) {
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
                    this.items.push(TestDto.fromJS(item));
            }
            this.totalCount = _data["totalCount"];
        }
    }

    static fromJS(data: any): TestDtoPagedResultDto {
        data = typeof data === 'object' ? data : {};
        let result = new TestDtoPagedResultDto();
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

    clone(): TestDtoPagedResultDto {
        const json = this.toJSON();
        let result = new TestDtoPagedResultDto();
        result.init(json);
        return result;
    }
}
export interface ITestDtoPagedResultDto {
    items: TestDto[] | undefined;
    totalCount: number;
}
export class CreateTestDto implements ICreateTestDto {
    code: string;
    name: string | undefined;
    description: string;
    tenantId: number | undefined;
    

    constructor(data?: ICreateTestDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.code = _data["code"];
            this.name = _data["name"];
            this.description = _data["description"];
            this.tenantId = _data["tenantId"];
        }
    }

    static fromJS(data: any): CreateTestDto {
        data = typeof data === 'object' ? data : {};
        let result = new CreateTestDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["code"] = this.code;
        data["name"] = this.name;
        data["description"] = this.description;
        data["tenantId"] = this.tenantId;
        return data; 
    }

    clone(): CreateTestDto {
        const json = this.toJSON();
        let result = new CreateTestDto();
        result.init(json);
        return result;
    }
}

export interface ICreateTestDto {
    code: string;
    name: string;
    description: string;
    tenantId: number | undefined;
}