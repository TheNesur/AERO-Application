#include "HX711.h"

const int LEDROUGE_PIN = 21;
const int LEDVERTE_PIN = 22; 

// init du capteur 1 (portance)

HX711 jauge1;
const int JAUGE1_DOUT_PIN = 33;
const int JAUGE1_SCK_PIN = 32;
float JAUGE1_SCALE;


// init du capteur 2 (trainée)

HX711 jauge2;
const int JAUGE2_DOUT_PIN = 27;
const int JAUGE2_SCK_PIN = 14;
float JAUGE2_SCALE; // Echelle définie par la suite


// init des pin pwm pour la liaison séries normalisés
const int PORTANCE_PWM_PIN = 26;
const int TRAINEE_PWM_PIN = 25;
const float rapportAOP = 3.25;
float eqgvoltport;
float eqgvolttrai;


// init des variables annexes

String cmdBuff = "";
String nxtcmdBuff = "";
bool start = false;
bool simu = false;
float delaims; // correspond au délai entre chaque transmission de mesure 
unsigned long gestiondelai;
float fakemes = 0;

void setup() {
  // démarrer la liaison série 2 à 9600 baud
  Serial2.begin(9600, SERIAL_8N1, 16, 17);  
  Serial2.setTimeout(2000);
    

  // Démarre la liaison avec les jauges en se basant sur la syntaxe de la librairie HX711
  jauge1.begin(JAUGE1_DOUT_PIN, JAUGE1_SCK_PIN, 128);
  jauge2.begin(JAUGE2_DOUT_PIN, JAUGE2_SCK_PIN, 128);



  pinMode(PORTANCE_PWM_PIN, OUTPUT); 
  pinMode(TRAINEE_PWM_PIN, OUTPUT); 
  pinMode(LEDROUGE_PIN, OUTPUT); 
  pinMode(LEDVERTE_PIN, OUTPUT); 

}

void loop() {
  // vérifier s'il y a des données disponibles sur la liaison série
 
  if (Serial2.available() > 0) {
    // lire la prochaine donnée disponible sur la liaison série
    String data = Serial2.readString();

    cmdBuff = cmdBuff + nxtcmdBuff;
    cmdBuff = cmdBuff + data;
    
    if (cmdBuff.indexOf("\r\n") != -1)
    {
        data = cmdBuff;
        cmdBuff = cmdBuff.substring(0, cmdBuff.indexOf("\r\n") + 2);
        nxtcmdBuff = cmdBuff.substring(cmdBuff.indexOf("\r\n") + 2); 
    }

    // vérifier si la donnée est égale à "START"
    if (cmdBuff.indexOf("START") >= 0) {
      start = true;

      String arg[10];
      int end = 0;
      int start = 0;
      for (int i = 0; i < 10; i++) {
        end = cmdBuff.indexOf(' ', start);
          if (end == -1) {
            end = cmdBuff.length();
          }
          arg[i] = cmdBuff.substring(start, end);
          start = end + 1;
      }

      String DelaiMes = arg[1];
      String EqPort = arg[3];
      String EqTra = arg[5];
      String EqJT = arg[7];
      String EqJP = arg[9];      
      delaims = DelaiMes.toFloat() *1000;
      JAUGE1_SCALE = EqJP.toFloat();
      JAUGE2_SCALE = EqJT.toFloat();
      eqgvoltport = EqPort.toFloat();
      eqgvolttrai = EqTra.toFloat();
      jauge1.set_scale(JAUGE1_SCALE);
      jauge2.set_scale(JAUGE2_SCALE);
      jauge1.tare();
      jauge2.tare();

      digitalWrite(LEDVERTE_PIN, HIGH);
      Serial2.println("MSG DEMARRAGE TRANSMISSION MESURE AVEC " + DelaiMes + " SECONDE(S) ENTRE CHAQUE MESURE (Portance maximum en mN : " + EqPort + "; Trainee maximum en mN : " + EqTra + "; echelle jauge trainee : "+ EqJT +"; echelle jauge portance : "+ EqJP +")");
      gestiondelai = millis();
      cmdBuff = "";
    }else if(cmdBuff.indexOf("STOP") >= 0){
      start = false;
      digitalWrite(LEDVERTE_PIN, LOW);
      cmdBuff = "";
    }else if(cmdBuff.indexOf("TARAGE") >= 0){
      Serial2.println("MSG TARAGE FAIT");
      jauge1.tare();
      jauge2.tare();
      cmdBuff = "";
    }else if(cmdBuff.indexOf("SIMU") >= 0){
      if(simu){
        simu=false;
        digitalWrite(LEDROUGE_PIN, LOW);
        Serial2.println("MSG Mode simulation désactivée");
        
      }else{
        simu=true;
        digitalWrite(LEDROUGE_PIN, HIGH);
        Serial2.println("MSG Mode simulation activée"); 
      }
      cmdBuff = "";
    }else if(cmdBuff.indexOf("GOCALIB") >= 0){
      jauge1.set_scale();
      jauge1.tare();
      jauge2.set_scale();
      jauge2.tare();
      Serial2.println("MSG GOCALIB OK"); // Démarrage du mode calibration, j'enlève toute les config précédente afin de procéder au calibrage (config précédente = offset.. tarage ..)
      cmdBuff = "";
    }else if(cmdBuff.indexOf("RAWTRAINEE") >= 0){ // Les valeurs "RAW" sont les valeurs brutes qui sont donc des valeurs qui ne sont pas lisible par l'homme mais qui permette a l'IHM
      float jttmp = jauge2.get_units(10);         // de défnir l'échelle
      Serial2.println(String("MSG TRAW: ") + jttmp);  // car ECHELLE = VALEURRAW / POIDSDEREFECENCE 
      cmdBuff = "";
    }else if(cmdBuff.indexOf("RAWPORTANCE") >= 0){
      float jptmp = jauge1.get_units(10);
      Serial2.println(String("MSG PRAW: ") + jptmp);
      cmdBuff = "";
    }else{
      Serial2.println("Commande inconnue reçue: " + data);
      cmdBuff = "";
    }
    
  }

  if(start){
    if(simu){
      if (millis() - gestiondelai >= delaims) {
        // String mesure = String("PORTANCE " ) + fakemes + String(" TRAINEE ") + fakemes + String(" ");
        // Serial2.println(mesure);

        // int traineeAnalog = fakemes * 251 / eqgvolttrai;
        // int portanceAnalog = fakemes * 251 / eqgvoltport;
        // dacWrite(TRAINEE_PWM_PIN, traineeAnalog);
        // dacWrite(PORTANCE_PWM_PIN, portanceAnalog);
        // String debugmsg = String("MSG SORTIEPORTANCE " ) + traineeAnalog + String(" SORTIE TRAINEE ") + portanceAnalog;
        // Serial2.println(debugmsg);
        // fakemes=fakemes+1;
        // if(fakemes > 33) fakemes=0;
        // gestiondelai = millis();
        Serial2.println((jauge2.get_units(10) * 10.0) / 10.0);
      }
    }else{
      if (millis() - gestiondelai >= delaims) {
        if (jauge1.wait_ready_timeout(1000) && jauge2.wait_ready_timeout(1000)) {
          digitalWrite(LEDROUGE_PIN, HIGH);
          float result1=round(jauge1.get_units(10) * 10.0) / 10.0;   // result1 = jauge trainée , result2 = jauge portance
          float result2=round(jauge2.get_units(10) * 10.0) / 10.0;  // Arrondi les valeurs des jauges de portance et de trainée 
          String mesure = String("PORTANCE " ) + abs(result1) + String(" TRAINEE ") + abs(result2); // string final a envoyer a l'utilisateur
          Serial2.println(mesure);
          int traineeAnalog = abs(result2) * 251 / eqgvolttrai; // 251 correspondant a 10V dans le système avec notre ampli OP afin d'obtenir Vmax = 10 V
          int portanceAnalog = abs(result1)  * 251 / eqgvoltport; // car si l'on prenait 255 vu que AmpliOP imparfait Vmax = 10.65V...
          analogWrite(TRAINEE_PWM_PIN, traineeAnalog); 
          analogWrite(PORTANCE_PWM_PIN, portanceAnalog);
          gestiondelai = millis();
          digitalWrite(LEDROUGE_PIN, LOW);
        }else{
          Serial2.println("MSG ERREUR DE LIAISON HX711");
        }
      } 
    }


  }
}
