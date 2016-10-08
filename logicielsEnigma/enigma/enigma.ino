const int letterA = 2;
const int letterB = 3;
const int letterC = 4;
const int letterD = 5;
const int letterE = 6;
const int letterF = 7;
const int letterG = 8;
const int letterH = 9;
const int letterI = 10;
const int letterJ = 11;
const int letterK = 12;
const int letterL = 13;
const int letterM = 14;
const int letterN = 15;
const int letterO = 16;
const int letterP = 17;
const int letterQ = 18;
const int letterR = 19;
const int letterS = 20;
const int letterT = 21;
const int letterU = 22;
const int letterV = 23;
const int letterW = 24;
const int letterX = 25;
const int letterY = 26;
const int letterZ = 27;
boolean sent =true;
int nbLetter = 25;

String allLetters = "11abcdefghijklmnopqrstuvwxyz";

void setup() {
  Serial.begin(9600);
}


void loop() {
  String charToCode = "";
  if(Serial.available() > 0){
    charToCode = Serial.readString();
    sent = false;

    setAllPinOut(allLetters.indexOf(charToCode.charAt(0)));
    setAllPinInExcept(allLetters.indexOf(charToCode.charAt(0)));
    digitalWrite(allLetters.indexOf(charToCode.charAt(0)), HIGH);
    /*Serial.println("lettre envoi : ");
    Serial.println(allLetters.indexOf(charToCode.charAt(0)));*/
    
    int lettreRecue;
    for(int x = letterB; x <= letterD; x++){
      int state = digitalRead(x);
      if(state == HIGH){
        
        lettreRecue = x;
        
      }
    }
    if(!sent){
      Serial.println(allLetters[lettreRecue]);
      sent = true;
    }
    delay(1500);
  }
}

void setAllPinOut(int pinOut){
  pinMode(pinOut, OUTPUT);
}

void setAllPinInExcept(int notPinIn){
  for(int x = 2; x <= 2 + nbLetter; x++){
    if(x != notPinIn){
      pinMode(x, INPUT);
    }
  }
}

