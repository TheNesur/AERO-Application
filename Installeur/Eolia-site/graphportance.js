

function afficherGraphique(trainee, portance,frequencemesure) {
    var ctx = document.getElementById('graph').getContext('2d');
    trainee=moyenneGlissante(txtVersFloat(trainee),5);
    portance=moyenneGlissante(txtVersFloat(portance),5);
    var labels =[];
    for (var i = 0; i < trainee.length; i++) {
        labels.push(i*frequencemesure);
    }

    var myChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: 'Données trainees',
                data: trainee,
                borderColor: 'rgba(40, 255, 145, 1)',
                borderWidth: 1
            },
            {
                label: 'Données portance',
                data: portance,
                borderColor: 'rgba(252, 142, 255, 1)',
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
}

function moyenneGlissante(arr, windowSize) {
    let result = [];
    for (let i = 0; i < arr.length - windowSize + 1; i++) {
      let sum = 0;
      for (let j = i; j < i + windowSize; j++) {
        sum += arr[j];
      }
      result.push(sum / windowSize);
    }
    return result;
  }
  
  function txtVersFloat(arr) {
    let floatArr = arr.map(function(str) {
      let floatVal = parseFloat(str);
      if (isNaN(floatVal)) {
          return 0;
      }
      return floatVal;
    });
    return floatArr;
  }
  