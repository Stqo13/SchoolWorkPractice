const btn = document.getElementById("btn");
const searchInput = document.getElementById("search");
const container = document.getElementById("characters");
const statusBox = document.getElementById("status");

btn.addEventListener("click", async () => {
  const name = searchInput.value.trim();
  container.innerHTML = "";
  statusBox.textContent = "Зареждане...";

  try {
    const res = await fetch(`https://rickandmortyapi.com/api/character/?name=${name}`);
    if (!res.ok) throw new Error("Грешка при заявката");

    const data = await res.json();

    if (!data.results || data.results.length === 0) {
      statusBox.textContent = "Няма намерени герои.";
      return;
    }

    data.results.forEach(ch => {
      const col = document.createElement("div");
      col.className = "col-12 col-sm-6 col-md-4 col-lg-3";

      col.innerHTML = `
        <div class="card h-100 shadow-sm">
          <img src="${ch.image}" class="card-img-top" alt="${ch.name}">
          <div class="card-body text-center">
            <h5 class="card-title">${ch.name}</h5>
            <p class="card-text small text-muted">${ch.species} – ${ch.status}</p>
          </div>
        </div>
      `;
      container.appendChild(col);
    });

    statusBox.textContent = `Намерени герои: ${data.results.length}`;
  } catch (err) {
    statusBox.textContent = "Възникна грешка при зареждането.";
  }
});
