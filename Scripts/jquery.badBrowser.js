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
		$("<div id='browserWarning'>�A�ҨϥΪ� Internet Explorer �s�����w�g�L�ɤF�C��ĳ�A�ɯŨ���s�������A�άO��Ψ�L���s�����A�H��o��n���ϥ�����C �ФɯŦ�<a href='http://www.mozilla.com/firefox/'>FireFox</a>, <a href='http://www.google.com/chrome'>Google Chrome</a>, <a href='http://www.apple.com/tw/safari/download/'>Safari</a> �� <a href='http://www.microsoft.com/windows/Internet-explorer/default.aspx'>Internet Explorer 8</a>. ����!&nbsp;&nbsp;&nbsp;[<a href='#' id='warningClose'>����</a>] </div> ")
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
