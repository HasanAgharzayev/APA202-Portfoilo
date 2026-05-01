


function createElement(tag, styles = {}, innerHTML = '') {
    const element = document.createElement(tag);
    Object.assign(element.style, styles);
    if (innerHTML) element.innerHTML = innerHTML;
    return element;
}


const card = createElement('div', {
    width: '340px',
    fontFamily: 'sans-serif',
    backgroundColor: '#ffffff',
    borderRadius: '10px',
    boxShadow: '0 4px 8px rgba(0,0,0,0.1)',
    margin: '40px auto',
    overflow: 'hidden',
    cursor: 'pointer',
    transition: 'transform 0.3s ease'
});

card.onmouseenter = () => card.style.transform = 'translateY(-5px)';
card.onmouseleave = () => card.style.transform = 'translateY(0)';


const imageBox = createElement('div', {
    height: '200px',
    backgroundImage: 'url("https://images.unsplash.com/photo-1512917774080-9991f1c4c750?auto=format&fit=crop&w=600&q=80")',
    backgroundSize: 'cover',
    position: 'relative'
});

const heartBtn = createElement('span', {
    position: 'absolute',
    top: '15px',
    right: '15px',
    fontSize: '26px',
    color: 'white',
    cursor: 'pointer',
    userSelect: 'none'
}, '♡');

heartBtn.onclick = (e) => {
    e.stopPropagation();
    const isLiked = heartBtn.innerText === '♥';
    heartBtn.innerText = isLiked ? '♡' : '♥';
    heartBtn.style.color = isLiked ? 'white' : '#ff4757';
};

imageBox.appendChild(heartBtn);


const contentBox = createElement('div', { padding: '20px' });
const type = createElement('p', { color: '#637381', fontSize: '12px', fontWeight: 'bold', margin: '0' }, 'DETACHED HOUSE • 5Y OLD');
const price = createElement('h2', { margin: '10px 0', fontSize: '28px', color: '#212B36' }, '$750,000');
const address = createElement('p', { color: '#637381', fontSize: '15px', margin: '0' }, '742 Evergreen Terrace');

contentBox.append(type, price, address);


const featuresBox = createElement('div', {
    display: 'flex',
    justifyContent: 'space-between',
    padding: '15px 20px',
    borderTop: '1px solid #DFE3E8',
    borderBottom: '1px solid #DFE3E8'
});

const bed = createElement('div', { fontSize: '14px', color: '#637381' }, '🛏️ <b style="color:#212B36">3</b> Bedrooms');
const bath = createElement('div', { fontSize: '14px', color: '#637381' }, '🛁 <b style="color:#212B36">2</b> Bathrooms');

featuresBox.append(bed, bath);


const realtorBox = createElement('div', { padding: '15px 20px' });
const realtorLabel = createElement('p', { color: '#919EAB', fontSize: '11px', fontWeight: 'bold', margin: '0 0 10px 0' }, 'REALTOR');

const realtorProfile = createElement('div', { display: 'flex', alignItems: 'center', gap: '15px' });
const avatar = createElement('img', { width: '45px', height: '45px', borderRadius: '50%', objectFit: 'cover' });
avatar.src = 'https://randomuser.me/api/portraits/women/44.jpg';

const realtorInfo = createElement('div');
const realtorName = createElement('div', { fontWeight: 'bold', color: '#212B36', fontSize: '15px' }, 'Tiffany Heffner');
const realtorPhone = createElement('div', { color: '#919EAB', fontSize: '14px', marginTop: '4px' }, '(555) 555-4321');

realtorInfo.append(realtorName, realtorPhone);
realtorProfile.append(avatar, realtorInfo);
realtorBox.append(realtorLabel, realtorProfile);


card.append(imageBox, contentBox, featuresBox, realtorBox);

document.body.style.backgroundColor = '#f4f7f6';
document.body.appendChild(card);