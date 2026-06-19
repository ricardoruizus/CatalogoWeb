(function () {
  var btn = document.getElementById('theme-toggle');
  var metaTheme = document.getElementById('meta-theme-color');
  if (!btn) return;

  function applyMeta(theme) {
    if (metaTheme) metaTheme.setAttribute('content', theme === 'light' ? '#ffffff' : '#000000');
  }
  function applyLabel(theme) {
    btn.setAttribute('aria-label', theme === 'light' ? 'Cambiar a modo oscuro' : 'Cambiar a modo claro');
  }

  var current = document.documentElement.getAttribute('data-theme') || 'dark';
  applyMeta(current);
  applyLabel(current);

  btn.addEventListener('click', function () {
    var next = document.documentElement.getAttribute('data-theme') === 'light' ? 'dark' : 'light';
    document.documentElement.setAttribute('data-theme', next);
    localStorage.setItem('catalogoweb-theme', next);
    applyMeta(next);
    applyLabel(next);
  });
})();