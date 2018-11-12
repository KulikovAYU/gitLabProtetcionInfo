 var FirstName;
 var Family;
 var LastName;

var BufColor;

window.onload = function(){preparePage();} ;

function preparePage() {
	
	document.getElementById("NavigatonPanel").style.display = "none";	//hide div
	HideAllQuestions();
	
	document.getElementById("BeginTest").onclick = function () {
	BufColor = document.getElementById("IdButtonFirstQuestion").style.background;
		if(Register())
		{
		document.getElementById("Registration").style.display = "none";		//hide div
		document.getElementById("FirstQuestion").style.display = "block";	//show div
		document.getElementById("NavigatonPanel").style.display = "block";	//show div	
		document.getElementById("IdButtonFirstQuestion").style.background="red";
		timer();
		}
	}
};

function HideAllQuestions(){
		document.getElementById("FirstQuestion").style.display = "none";	//hide div (1-st question)
		document.getElementById("SecondQuestion").style.display = "none";//hide div (2-st question)
		document.getElementById("ThirdQuestion").style.display = "none";//hide div (3-rd question)
		document.getElementById("FourQuestion").style.display = "none";//hide div (4-rd question)
		document.getElementById("FiveQuestion").style.display = "none";//hide div (5-ve question)
		document.getElementById("SixQuestion").style.display = "none";//hide div (6-x question)
		document.getElementById("SevenQuestion").style.display = "none";//hide div (7-ven question)
		document.getElementById("EightQuestion").style.display = "none";//hide div (8-th question)
		document.getElementById("NineQuestion").style.display = "none";//hide div (9-ne question)
		document.getElementById("TenQuestion").style.display = "none";//hide div (10-en question)
}

function ResetBackGround()
{
	var buttons = document.getElementsByClassName("dws-question");
	
	for(var nBtn=0; nBtn < buttons.length; nBtn++)
		buttons[nBtn].style.background = BufColor; 
}

function ShowQuestions(NumberOfQuestion){

	switch(NumberOfQuestion)
		{
		case 1: HideAllQuestions(); document.getElementById("FirstQuestion").style.display = "block";
				ResetBackGround();
				document.getElementById("IdButtonFirstQuestion").style.background="red";
				break; 	//show div	
		case 2: HideAllQuestions(); document.getElementById("SecondQuestion").style.display = "block";
				ResetBackGround();
				document.getElementById("IdButtonSecondQuestion").style.background="red";
				break;	//show div
		case 3: HideAllQuestions(); document.getElementById("ThirdQuestion").style.display = "block";
				ResetBackGround();
				document.getElementById("IdButtonThirdQuestion").style.background="red";
				break;	//show div
		case 4: HideAllQuestions(); document.getElementById("FourQuestion").style.display = "block"; 
				ResetBackGround();
				document.getElementById("IdButtonFourQuestion").style.background="red";
				break; 	//show div	
		case 5: HideAllQuestions(); document.getElementById("FiveQuestion").style.display = "block"; 
				ResetBackGround();
				document.getElementById("IdButtonFiveQuestion").style.background="red";
				break;	//show div
		case 6: HideAllQuestions(); document.getElementById("SixQuestion").style.display = "block"; 
				ResetBackGround();
				document.getElementById("IdButtonSixQuestion").style.background="red";
				break;	//show div		
		case 7: HideAllQuestions(); document.getElementById("SevenQuestion").style.display = "block";
				ResetBackGround();
				document.getElementById("IdButtonSevenQuestion").style.background="red";
				break;	//show div
		case 8: HideAllQuestions(); document.getElementById("EightQuestion").style.display = "block";
				ResetBackGround();
				document.getElementById("IdButtonEightQuestion").style.background="red";
				break; 	//show div	
		case 9: HideAllQuestions(); document.getElementById("NineQuestion").style.display = "block"; 
				ResetBackGround();
				document.getElementById("IdButtonNineQuestion").style.background="red";
				break;	//show div
		case 10: HideAllQuestions(); document.getElementById("TenQuestion").style.display = "block"; 
				ResetBackGround();
				document.getElementById("IdButtonTenQuestion").style.background="red";
				break;	//show div	
		default: HideAllQuestions(); document.getElementById("FirstQuestion").style.display = "block"; 
				ResetBackGround();
				document.getElementById("IdButtonFirstQuestion").style.background="red";
				break; //show div	
		}
}

 var Register = function Registration() {

	FirstName = document.getElementById('IDFirstName').value;
	Family = document.getElementById('Family').value;
 	LastName = document.getElementById('LastName').value;
	 
 	if ((FirstName != '') && (Family != '') && (LastName != '')) {
 		alert('Регистрация пройдена. Переход в режим тестирования!');
		return true;

 	} else {
		var OutRegstrationMessage;
		OutRegstrationMessage = document.getElementById('ErrRegistrationMessage');
 		OutRegstrationMessage.innerHTML = 'Внимание! Заполните все поля формы';
		return false;
 	}
 };
var timeIsOff = false;
 var timer = function startTimer() {

 	alert(window.FirstName);
 	t = setInterval(function () {
 		var s = document.getElementById('mT'),
 			f = function (x) {
 				return (x / 100).toFixed(2).substr(2);
 			},
 			d = ':',
 			y = s.innerHTML.split(d),
 			z = --y[2] + y[0] * 3.6e3 + y[1] * 60;
		if(!z) {timeIsOff = true;clcResults();}
 		//  if (!z) clearInterval (t); 
 		s.innerHTML = [
            f(Math.floor(z / 3600)),
            f(Math.floor(z % 3600 / 60)),
            f(z % 3600 % 60)
        ].join(d);
 	}, 1000);
 };


function FinishTesting() {
	//alert("CLICK");
	var finishTesting = document.getElementById('finishTesting'),
		confirmFinishDialog = document.getElementById('confirm-finish');

	finishTesting.onclick = function () {
		confirmFinishDialog.showModal();

		document.getElementById("cancel").onclick = function () {
			confirmFinishDialog.close();
		}
		document.getElementById("yes").onclick = function () {
			if (!timeIsOff) {
				// Написать если время еще не вышло
				alert("TODO!!");
				clcResults();
				confirmFinishDialog.close();
			} else {
				alert("если время вышло, то завершить тестирование");
				//если время вышло, то завершить тестирование  
			}
		}

	};

};

var countOfTrueAnswers = 0;

function clcResults(){
	
//Проверяем ответы
	//1.Вопрос
var answer1 =CheckResult('firstQestRadio',1);	
var answer2 =CheckResult('firstQestRadio',1);
	
	

 alert("Считаем ответы");	
};

function CheckResult(NameRadio, nCntOfTrueAnswers) {
	var allCntAnswers = 5;

	switch (nCntOfTrueAnswers) {

		case 1:
			var answer1 = document.getElementsByName(NameRadio);
			for (var nAns = 0; nAns < answer1.length; nAns++) {
				if (answer1[nAns].value == "true") {
					countOfTrueAnswers++;
					break;
				}

			}
			break;
			
		case 2:
			var answer2 = document.getElementsByName(NameRadio);
			var localTrueAnswers =0;
			for (var nAns = 0; nAns < answer2.length; nAns++) {
				if (answer1[nAns].value == "true") {
					localTrueAnswers++; 
					countOfTrueAnswers++;
					break;
				}

			}
			break;	


	}
};

//Функция обрабатывает блоки ответов в зависимости от количества правильных ответов и выдает true в случае, если все ответы найдены
function PrepareAnswers(answer, TrueAnswers) {
var localTrueAnswers =0;
	for (var nAns = 0; nAns < answer.length; nAns++) {
		if (answer[nAns].value == "true") {
			localTrueAnswers++;
			countOfTrueAnswers++;
			break;
		}

	}
};