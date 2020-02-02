export default {
    Plues8ToLocal:function(date){
        var zone = 8;
        var lzd = new Date().getTimezoneOffset();
        var l = date.getTime();
        var d = new Date(l + lzd * 60 * 1000 + zone * 60 * 60 * 1000);

        return d;
    },
    LocalToPlues8:function(date){        
        var l = date.getTime();
        var lzd = date.getTimezoneOffset();
        var localzone = 8;
        var d = new Date(l + lzd * 60 * 1000 + localzone * 60 * 60 * 1000);

        return d;
    },
    Plues8ToLocalString:function(date){
        var d = this.Plues8ToLocal(date);
        return this.Date2String(d);
    },
    LocalToPlues8String:function(date){
        var d = this.LocalToPlues8(date);
        return this.Date2String(d);
    },
    Plues8StringToLocalString : function(date){
        var d = this.String2Date(date);
        var d = this.Plues8ToLocal(d);
        return this.Date2String(d);
    },
    LocalStringToPlues8String:function(date){
        var d = this.String2Date(date);
        d = this.LocalToPlues8(d);
        return this.Date2String(d);
    },
    Date2String :function(d){
        var s = d.getFullYear().toString();
        var mon = d.getMonth() + 1;
        var day = d.getDate();
        if(mon<10){
            mon = '0'+mon.toString();
        }else{
            mon = mon.toString();
        }

        if(day<10){
            day = '0'+day.toString();
        }else{
            day = day.toString();
        }
        s = s + '-' + mon + '-' + day + ' ';
        s = s + d.getHours().toString() + ':' + d.getMinutes().toString() + ":" + d.getSeconds().toString();
        return s;
    },
    String2Date:function(ds){
        var dstemp = ds.split('.')[0];
        dstemp = dstemp.split(' ');
        var datesplit = dstemp[0].split('-');
        var timesplit = dstemp[1].split(':');
        var year = datesplit[0];
        var month = datesplit[1]-1;
        var day = datesplit[2];
        var hour = timesplit[0];
        var min = timesplit[1];
        var sec = timesplit[2];

        return new Date(year,month,day,hour,min,sec,0);
        
    }
}