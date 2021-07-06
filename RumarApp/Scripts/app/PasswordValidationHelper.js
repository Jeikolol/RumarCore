var colors = ['#F00', '#F90', '#FF0', '#9F0', '#0F0'];

function measureStrength(p) {
    var $minLength = 8;
    let force = 0;

    const regexSymbols = /[$-/:-?{-~!"^_`\[\]]/g;
    const lowerLetters = /[a-z]+/.test(p);
    const upperLetters = /[A-Z]+/.test(p);
    const numbers = /[0-9]+/.test(p);

    const symbols = regexSymbols.test(p);
    const flags = [lowerLetters, upperLetters, numbers, symbols];
    let passedMatches = 0;

    for (let flag of flags) {
        passedMatches += flag === true ? 1 : 0;
    }

    force += 2 * p.length + ((p.length >= 10) ? 1 : 0);
    force += passedMatches * 10;

    // penality (short password)
    force = (p.length < $minLength) ? Math.min(force, 10) : force;

    // penality (poor variety of characters)
    force = (passedMatches === 1) ? Math.min(force, 10) : force;
    force = (passedMatches === 2) ? Math.min(force, 20) : force;
    force = (passedMatches === 3) ? Math.min(force, 40) : force;

    return force;
}

function getColor(s) {
    let idx = 0;
    if (s <= 10) {
        idx = 0;
    }
    else if (s <= 20) {
        idx = 1;
    }
    else if (s <= 30) {
        idx = 2;
    }
    else if (s <= 40) {
        idx = 3;
    }
    else {
        idx = 4;
    }
    return {
        idx: idx + 1,
        col: this.colors[idx]
    };
}

function getStrengthIndexAndColor(password) {
    return getColor(measureStrength(password));
};