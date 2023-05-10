document.addEventListener('DOMContentLoaded', function() {
  const configForm = document.getElementById('config-form');
  const appSettings = <?php echo json_encode($config->appSettings); ?>;

  Object.keys(appSettings).forEach(function(key) {
    const tr = document.createElement('tr');
    const tdKey = document.createElement('td');
    const tdValue = document.createElement('td');
    const input = document.createElement('input');
    input.type = 'text';
    input.name = key;
    input.value = appSettings[key];
    tdKey.textContent = key;
    tdValue.appendChild(input);
    tr.appendChild(tdKey);
    tr.appendChild(tdValue);
    configForm.querySelector('table').appendChild(tr);
  });
});
