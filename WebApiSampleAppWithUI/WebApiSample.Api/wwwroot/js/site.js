const uri = 'api/Assets';
let assets = [];

function getAssets() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get assets.', error));
}

function addAsset() {
    const addNameTextbox = document.getElementById('add-name');
    const addValueTextbox = document.getElementById('add-assetValue');

    const asset = {
        value: parseFloat(addValueTextbox.value.trim()),
        name: addNameTextbox.value.trim()
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(asset)
    })
        .then(response => response.json())
        .then(() => {
            getAssets();
            addNameTextbox.value = '';
            addValueTextbox.value = '';
        })
        .catch(error => console.error('Unable to add asset.', error));
}

function deleteItem(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getAssets())
        .catch(error => console.error('Unable to delete asset.', error));
}

function displayEditForm(id) {
    document.getElementById('editFormLoading').style.visibility = 'visible';
    document.getElementById('editFormLoading').style.display = 'block';
    fetch(`${uri}/${id}`, {
        method: 'GET'
    }).
         then(response => response.json())
        .then(function (asset) {
            document.getElementById('edit-name').value = asset.name;
            document.getElementById('edit-id').value = asset.id;
            document.getElementById('edit-assetValue').value = asset.value;
            document.getElementById('editForm').style.display = 'block';

            document.getElementById('editFormLoading').style.display = 'none';
        }).catch(error => console.error('Unable to get item.', error));

    //const item = items.find(item => item.id === id);

    
}

function updateItem() {
    const assetId = document.getElementById('edit-id').value;
    const asset = {
        id: parseInt(assetId, 10),
        value: parseFloat(document.getElementById('edit-assetValue').value.trim()),
        name: document.getElementById('edit-name').value.trim()
    };

    fetch(`${uri}/${assetId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(asset)
    })
        .then(() => getAssets())
        .catch(error => console.error('Unable to update item.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}

function _displayCount(itemCount) {
    const name = (itemCount === 1) ? 'Asset' : 'Assets';

    document.getElementById('counter').innerText = `${itemCount} ${name}`;
}

function _displayItems(data) {
    const tBody = document.getElementById('assets');
    tBody.innerHTML = '';

    _displayCount(data.length);

    const button = document.createElement('button');

    data.forEach(item => {
        

        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${item.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteItem(${item.id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(item.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let valueNode = document.createTextNode(item.value);
        td2.appendChild(valueNode);

        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });

    assets = data;
}