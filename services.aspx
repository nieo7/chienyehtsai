<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCH.master" AutoEventWireup="true" CodeFile="services.aspx.cs" Inherits="services" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
<script type="text/javascript" src="scripts/jquery.badBrowser.js" charset="big5"></script>
<script type="text/javascript" src="scripts/swfobject.js"></script>
<script type="text/javascript" src="scripts/smartRollover.js"></script>
<script type="text/javascript" src="scripts/jcarousellite_1.0.1.min.js"></script>
<script type="text/javascript" src="Scripts/jquery.cycle.all.js"></script>
<script type="text/javascript" src="Scripts/jquery.totemticker.js"></script>
<script type="text/javascript" src="Scripts/jquery.li-scroller.1.0.js"></script>
<script type="text/javascript" src="Scripts/MSClass1.65.js"></script>
<script type="text/javascript" src="Scripts/MSClass.js"></script>
<style type="text/css">
    #slider{
        clear:both;
        height:280px;
        width:730px;
        padding:0;
        margin:0 auto;
        z-index:0;
        display:block;
        }
</style>
<script type="text/javascript">
    $(function () {
        $('#slider').cycle({
            fx:   'fade',
            speed: 2000,
            timeout: 1000,
            random: 1
        });
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!-- InstanceBeginEditable name="EditRegion3" -->
            <div id="banner">
                <img src="img/services/img_bannerservices.jpg">
                <%--<div id="slider">
                <img src="img/services/img_bannerservices1.jpg" />
                <img src="img/services/img_bannerservices2.jpg" />
                <img src="img/team/img_bannerteam.jpg" />
                </div>--%>
            <%--<div id="marqueedefault">
                <img src="img/services/img_bannerservices1.jpg" />
                <img src="img/services/img_bannerservices2.jpg" />
                <img src="img/team/img_bannerteam.jpg" />
            </div>--%>
            	<%--<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" width="730" height="280" title="banner">
                <param name="movie" value="flash/services_banner.swf">
                <param name="quality" value="high">
                <embed src="flash/services_banner.swf" quality="high" type="application/x-shockwave-flash" width="730" height="280"></embed>
              	</object>--%>
            </div>
		  <!-- InstanceEndEditable -->
            
          <div id="bannershadow"><img src="img/home/img_bannershadow.png"></div>

           <!-- InstanceBeginEditable name="EditRegion4" -->
        <div id="center">
        	<div id="tital"><img src="img/services/img_titallogo.jpg" alt="">　專業服務</div>
            <div id="content_about">
            <ul>
            	<li><img src="img/home/dot.png"> <span class="font_bunder">前言</span>
					<p>　　建業高雄所在相關法律服務領域經驗豐富，透過在地之關懷，及時回應客戶需求，在南部地區已建立優良口碑。秉持專業服務及追求卓越之精神，並透過與會計師長期互動模式，為客戶面臨之法律糾紛及風險評估，提供縝密及快速之法律分析意見或解決方案，深受企業法人及自然人客戶長期之信賴與佳許。</p><br>
              	</li>
                <li><img src="img/home/dot.png"> <span class="font_bunder">仲裁及訴訟案件之辦理（民事、刑事、行政訴訟）</span>
                	<p>　　仲裁是基於私法自治而設立的紛爭解決機制，具有快速、有效、專家判斷及保密等優點，高度尊重當事人自主原則。且一經仲裁人之判斷，即告確定，與法院之確定判決具有同一效力，可使當事人減免訟累。仲裁常被當事人選擇作為工程、商務或其他履約爭議之解決方式。本所有豐富之仲裁經驗。</p><br>
               	  	<p>　　此外，民事、刑事及行政訴訟案件，向為律師業務之核心內容，而有別於過往之傳統訴訟案件，現今的訴訟類型趨於專業化、複雜化，以個人之力，將難以勝任多元之案件類型。本所依照律師個人學經歷及專業背景，予以分工分組，透過各律師之專業領域及知識經驗，以相互討論的方式，收集思廣益的效果，維護當事人的權益。</p><br>
                    <p>　　民事紛爭解決程序，具有相當多元的管道，透過法院以判決定紛止爭僅是其中之一，調解、協商及仲裁，亦逐漸成為主流的紛爭解決途徑，本所不論於訴訟或調解、仲裁等非訟程序，均累積有相當豐富之經驗。承辦類型除傳統民事爭議、侵權賠償案件外，亦及於家事事件、不動產交易、連動債等金融商品糾紛、公司股權、票據、政府採購及公共工程、勞動爭議...等。</p><br>
                    <p>　　建業高雄所承辦之刑事案件以與專業性質相關者為多，例如涉及金融法規、工程法規、環保法規及政府採購等相關刑事訴訟內容為主。本所就受託承辦之刑事案件，均以捍衛及維護當事人權益之立場為出發點，實績灼然。</p><br>
                    <p>　　行政訴訟的重點在於行政法規、大法官解釋、法院實務判決以及主管機關相關解釋函令之研析。因前所長蔡欽源律師係公法學專業背景出身，熟稔此一領域，其影響所及，本所有專攻公法法學之律師，於承辦案件時，亦擅於蒐集、分析相關法令及主管機關函釋，暨彙整比較有關之案例，可為當事人提供全方位之法律評估，並爭取有利之判決結果。</p><br>
              	</li>
                <li><img src="img/home/dot.png"> <span class="font_bunder">法律顧問</span>
                	<p>　　本所受聘為多家公司企業之法律顧問，有高科技，亦有傳統產業。所跨領域包括上市櫃公司之相關法令、契約條文之擬定或增修、商事法規適用疑義、公司治理制度之建立及訴(非)訟策略之分析等企業營運所面臨之法律問題，本所皆已累積相當之處理經驗，可為企業提供迅速之診斷諮詢服務，俾利企業得預知潛在法律風險，有如企業家庭醫師一般，有效降低後續處理成本及對營運之衝擊。</p><br>
                </li>
                <li><img src="img/home/dot.png"> <span class="font_bunder">法律查核</span>
                	<p>　　伴隨鼓勵規模經濟及放寬資本市場籌資管道等政策，近年來企業透過合併、收購、分割及申請上市櫃等程序來擴展、調整營運規模或資本額，屢見不鮮。然而，企業在面臨此重大經營策略之調整時，為正確評估可能之財務及法律風險，必需先透過嚴謹之查核程序，以了解目標公司之實際價值及潛在法律風險，並為配合主管機關規範，須由專業律師查核後出具法律意見書，做為評價依據。本所專業團隊於此領域內亦已累積專業經驗，可配合客戶規劃時程，與會計師及財務顧問密切合作，提供法律查核及撰擬律師意見書之服務。</p><br>
                </li>
                <li><img src="img/home/dot.png"> <span class="font_bunder">商務契約之研擬/審閱/議定</span>
                	<p>　　就一般公司普遍於業務上可能需要之各項法律服務及可能遇到之相關法律問題等，本所亦能本於專業迅速而正確地提供公司相關之法律服務，包含各項商務契約之研擬、審閱以及議定等，盼能在各項合約研擬、審閱以及議定之過程中，預先避免風險、降低風險，在紛爭發生前先予以預防，而非僅在紛爭發生後才被動地被迫參與紛爭解決的過程。</p><br>
                    <p>　　身為專業律師，建業高雄所為客戶設想的，是各項商務決策前相關法律風險的分析及告知，提供客戶作為商務決策之參考；對於法律顧問客戶的託付，則以避免爭議產生為服務的中心思想，以此原則提供商務契約研擬、審閱以及議定之建議。</p><br>
                </li>
                <li><img src="img/home/dot.png"> <span class="font_bunder">促參案</span>
                	<p>　　促進民間參與公共建設法 (下稱，促參法) 自2000年2月9日公布施行迄今已歷十餘年，為國內引入民間資金興辦公共工程之法源依據。舉凡交通建設、重大商業設施、農業設施、文教設施、觀光遊憩重大設施、衛生醫療設施及運動設施等十三項公共建設，均可依循促參法引進民間資金，依個案實際需求以不同模式規劃。由於可興辦之公共建設種類多樣，興辦方式多元，且不同類型之公共建設涉及之相關行政法規亦有不同，是以，適切的法律規劃及法律諮詢為促進民間參與公共建設案件不可或缺之一環。尤其近年來，除政府規劃外，民間規劃方式亦逐漸浮現，民間投資人或主辦機關如何經由專業顧問，適法妥適地完成該公共建設之規劃案，殊屬重要。</p><br>
                    <p>　　建業高雄所於交通建設、重大商業設施、農業設施、文教設施、觀光遊憩重大設施、衛生醫療設施及運動設施等各類型促參案件均有豐富經驗，多次擔任政府方或民間投資人之法律顧問，從協助進行政府自辦及民間自提促參案件之可行性評估、先期規劃、招商文件及投資契約之撰擬，議約、簽約及履約管理，乃至於後續爭議之處理（協調委員會之召開、仲裁或訴訟），均可提供主辦機關及民間投資人最專業適切之法律服務。以期合理兼顧公益及投資廠商之利益，提升公共服務水準。</p><br>
                </li>
                <li><img src="img/home/dot.png"> <span class="font_bunder">政府採購爭議</span>
                	<p>　　建業高雄所長期擔任南部地區著名工程之監造、履約管理(PCM)之法律顧問，就國內公共工程之理論與實務等，累積豐富之經驗，舉凡大眾運輸系統、公路橋樑、機場、公共休閒設施、污水下水道、辦公大樓等案件，近年具體個案如海洋流行音樂中心、高雄市立圖書館總館、高雄世貿會議展覽中心等新建工程等，本所就有關政府採購契約之擬定、備標、招標、審標之作業有關諮詢、國際競圖契約審閱、履約期間契約解釋及變更等事項之處理，乃至工程索賠爭議調解、仲裁及訴訟及公務員貪污、圖利刑事辯護等案件，均有深厚之採購法律實務經驗，可提供專業、快速及高品質之法律服務。</p><br>
                    <p>有關政府採購案件服務範圍，包括：<br>
                    	<ul>
                        	<li>A.　招標、審標、決標作業：</li>
                            <li>　　分析政府採購相關法令</li>
                            <li>　　審閱招標文件</li>
                            <li>　　處理投、開標程序之爭議</li>
                            <li>　　法律顧問服務</li>
                        	
                        	<li>B.　履約管理</li>
                            <li>　　審閱契約、履約進度管理</li>
                            <li>　　契約疑義諮詢</li>
                            <li>　　相關付款爭議之處理</li>
                            
                            <li>C.　爭議處理</li>
                            <li>　　代理政府採購民、刑事及行政訴訟</li>
                            <li>　　代理政府採購異議、申訴、調解等事件</li>
                            <li>　　代理政府採購仲裁事件</li>
                        </ul>
					</p><br>
                </li>
                <li><img src="img/home/dot.png"> <span class="font_bunder">公司上市櫃(包含回台上市櫃)</span>
                	<p>　　當公司經營規模達到一定架構時，因籌資之需求、企業版圖的再次擴大等種種考慮，會將公司所發行的股票在公開市場上發行、買賣以募集資金。本所可協助客戶為適當之調整，以符合相關的證券管理法令，俾便順利完成公開發行以及後續發行工作，並可經由發行前之實地查核程序，發現公司在過去經營上的法律風險，提出改進之建議，以增加公司的價值。</p><br>
                    <p>　　近年來，我國相關證券管理法規對於「鮭魚返鄉」提供誘因，吸引優良台資海外企業回台上市櫃，本所亦有成功輔導返台上市櫃成功之經驗，可提供之服務包含協助海外企業進行回台上市櫃前之集團組織重組及法令遵循建議，且協調外國律師對海外企業進行法律查核並出具法律意見書，並審閱公開說明書及其他上市文件並協助海外企業其他法令遵循事宜，亦曾擔任海外企業來台上市櫃承銷商之法律顧問。且依證券主管機關要求下，對海外企業律師之法律意見以及查核之結果進行覆核，並且協助證券承銷商審閱海外企業公開說明書及其他法律文件等等。</p><br>
                </li>
			</ul>
			</div>
        <div class="top"><a href="#top"></a></div>
        </div>
        <!-- InstanceEndEditable -->
        <%--<script type="text/javascript">
            var Marquee1 = new Marquee("marqueedefault")
            Marquee1.Direction = 0;
            Marquee1.Step = 2;
            Marquee1.Width = 730;
            Marquee1.Height = 280;
            Marquee1.Timer = 100;
            Marquee1.DelayTime = 0;
            Marquee1.WaitTime = 0;
            Marquee1.ScrollStep = 52;
            Marquee1.Start();
    </script>--%>
</asp:Content>

