function badBrowser(){
	if($.browser.msie && parseInt($.browser.version) <= 6){ return true;}
	
	return false;
}

function getBadBrowser(c_name)
{
	if (document.cookie.length>0)
	{
	c_start=document.cookie.indexOf(c_name + "=");
	if (c_start!=-1)
		{ 
		c_start=c_start + c_name.length+1; 
		c_end=document.cookie.indexOf(";",c_start);
		if (c_end==-1) c_end=document.cookie.length;
		return unescape(document.cookie.substring(c_start,c_end));
		} 
	}
	return "";
}	

function setBadBrowser(c_name,value,expiredays)
{
	var exdate=new Date();
	exdate.setDate(exdate.getDate()+expiredays);
	document.cookie=c_name+ "=" +escape(value) + ((expiredays==null) ? "" : ";expires="+exdate.toGMTString());
}

if(badBrowser() && getBadBrowser('browserWarning') != 'seen' ){
	$(function(){
		$("<div id='browserWarning'>你所使用的 Internet Explorer 瀏覽器已經過時了。建議你升級到較新的版本，或是改用其他的瀏覽器，以獲得更好的使用體驗。 請升級至<a href='http://www.mozilla.com/firefox/'>FireFox</a>, <a href='http://www.google.com/chrome'>Google Chrome</a>, <a href='http://www.apple.com/tw/safari/download/'>Safari</a> 或 <a href='http://www.microsoft.com/windows/Internet-explorer/default.aspx'>Internet Explorer 8</a>. 謝謝!&nbsp;&nbsp;&nbsp;[<a href='#' id='warningClose'>關閉</a>] </div> ")
			.css({
				backgroundColor: '#fcfdde',
				'width': '100%',
				'border-top': 'solid 1px #aaa',
				'border-bottom': 'solid 1px #aaa',
				'text-align': 'center',
				padding:'5px 0px 5px 0px'
			})
			.prependTo("body");
		
		$('#warningClose').click(function(){
			setBadBrowser('browserWarning','seen');
			$('#browserWarning').slideUp('slow');
			return false;
		});
	});	
}
