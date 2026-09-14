// Change PORT to match your API project
const API_BASE = 'http://localhost:5078/api/pokemon';
const listEl = document.getElementById('pokemon-list');
const searchBtn = document.getElementById('search-btn');
const showAllBtn = document.getElementById('show-all-btn');

function renderPokemon(pokemonArray) {
    listEl.innerHTML = '';

    for (const pokemon of pokemonArray) {
        const item = document.createElement('li');
        item.innerHTML = `
                    <strong>${pokemon.name}</strong> (#${pokemon.id}) - ${pokemon.type}
                    ${pokemon.isLegendary ? ' [Legendary]' : ''}
                    <br>
                    <img src="${pokemon.imageUrl}" alt="${pokemon.name}" width="96" height="96">
                `;
        listEl.appendChild(item);
    }
}

async function loadAllPokemon() {
    const response = await fetch(API_BASE);
    const data = await response.json();
    renderPokemon(data);
}

async function searchPokemon() {
    const name = document.getElementById('search-input').value.trim();
    if (!name) {
        loadAllPokemon();
        return;
    }

    const response = await fetch(`${API_BASE}/${encodeURIComponent(name)}`);
    if (!response.ok) {
        listEl.innerHTML = `<li>No Pokemon found matching "${name}"</li>`;
        return;
    }

    const pokemon = await response.json();
    renderPokemon([pokemon]);
}

searchBtn.addEventListener('click', searchPokemon);
showAllBtn.addEventListener('click', loadAllPokemon);

// Load all Pokemon on initial page load
loadAllPokemon();
