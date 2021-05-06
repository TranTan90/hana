function newWin(url,width,height){
	var winl = (screen.width-width)/2;
	var wint = (screen.height-height)/2;

    var newWinows=window.open(url,"newWin","toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizeable=no,width="+width+",height="+height+",top="+wint+",left="+winl);
}

function newWinByName(url,name,width,height){
	var winl = (screen.width-width)/2;
	var wint = (screen.height-height)/2;
    var newWinows=window.open(url,name,"toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizeable=no,width="+width+",height="+height+",top="+wint+",left="+winl);
}

function newWinByNameByScroll(url,name,width,height){
	var winl = (screen.width-width)/2;
	var wint = (screen.height-height)/2;
    var newWinows=window.open(url,name,"toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizeable=no,width="+width+",height="+height+",top="+wint+",left="+winl);
}


function confirmMove(message,url){
	if(confirm(message)){
        window.location=url;
    }else{
        return;
    }
}

/**
* 쿠키 셋팅cài đặt cookie 
*/
function setCookie( name, value, expiredays )
{
    var todayDate = new Date();
    todayDate.setDate( todayDate.getDate() + expiredays );
    document.cookie = name + '=' + escape( value ) + '; path=/; expires=' + todayDate.toGMTString() + ';'
	return;
}

/**
* 쿠키 가져오기 lấy cookie
*/
function getCookie( name ) 
{ 
	var nameOfCookie = name + "="; 
	var x = 0; 
	while ( x <= document.cookie.length ) 
	{ 
		var y = (x+nameOfCookie.length); 
		if ( document.cookie.substring( x, y ) == nameOfCookie ) { 
			if ( (endOfCookie=document.cookie.indexOf( ";", y )) == -1 ) 
				endOfCookie = document.cookie.length; 
				return unescape( document.cookie.substring( y, endOfCookie ) ); 
		} 
		x = document.cookie.indexOf( " ", x ) + 1; 
		if ( x == 0 ) 
		break; 
	} 
	return ""; 
} 


/**
* 최대화 하여 창 띄우기 xem full màn hình 
*/
function FullScreen(){
	var width=screen.width;
	var height=screen.height;
	self.moveTo(0,0);
	window.resizeTo(width,height);
}

/*
function confirmMove(message,url,windowObj){
	if(confirm(message)){
        windowObj.location=url;
    }else{
        return;
    }
}
*/