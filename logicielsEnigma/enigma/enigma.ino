/*
 * const int letterA = 13;
const int letterB = 12;
const int letterC = 11;
const int letterD = 10;
const int letterE = 9;
const int letterF = 8;
const int letterG = 7;
const int letterH = 6;
const int letterI = 5;
const int letterJ = 4;
const int letterK = 3;
const int letterL = 2;
const int letterM = 22;
const int letterN = 23;
const int letterO = 24;
const int letterP = 25;
const int letterQ = 26;
const int letterR = 27;
const int letterS = 28;
const int letterT = 29;
const int letterU = 30;
const int letterV = 31;
const int letterW = 32;
const int letterX = 33;
const int letterY = 34;
const int letterZ = 35;
*/

const int lettres[] = {13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35};
boolean sent =true;
int nbLetter = 26;

/*String allLetters[40] = {" "};*/
String allLetters = "00lkjihgfedcba00000000mnopqrstuvwxyz";

void setup() {
  Serial.begin(9600);
  /*allLetters[13] = "a";
  allLetters[12] = "b";
  allLetters[11] = "c";
  allLetters[10] = "d";
  allLetters[9] = "e";
  allLetters[8] = "f";
  allLetters[7] = "g";
  allLetters[6] = "h";
  allLetters[5] = "i";
  allLetters[4] = "j";
  allLetters[3] = "k";
  allLetters[2] = "l";
  allLetters[22] = "m";
  allLetters[23] = "n";
  allLetters[24] = "o";
  allLetters[25] = "p";
  allLetters[26] = "q";
  allLetters[27] = "r";
  allLetters[28] = "s";
  allLetters[29] = "t";
  allLetters[30] = "u";
  allLetters[31] = "v";
  allLetters[32] = "w";
  allLetters[33] = "x";
  allLetters[34] = "y";
  allLetters[35] = "z";*/
}


void loop() {
  String charToCode = "";
  if(Serial.available() > 0){
    charToCode = Serial.readString();
    sent = false;
    int pin = allLetters.indexOf(charToCode.charAt(0));
    setAllPinOut(pin);
    setAllPinInExcept(pin);
    digitalWrite(pin, HIGH);
    /*Serial.println("lettre envoi : ");
    Serial.println(allLetters.indexOf(charToCode.charAt(0)));*/
    
    int lettreRecue;
    for(int x = 0; x < nbLetter; x++){
      int state = digitalRead(x);
      if(state == HIGH && lettres[x] != pin){
        
        lettreRecue = lettres[x];
        
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
  for(int x = 0; x < nbLetter; x++){
    if(lettres[x] != notPinIn){
      pinMode(lettres[x], INPUT);
    }
  }
}

