import React from 'react';
import {shallow} from 'enzyme';
import ComicCount from './ComicCount';

describe('<ComicCount />', () => {
  it('should be an div element', () => {
    const props = {
      count: 5
    };
    const wrapper = shallow(<ComicCount {...props} />);
    const actual = wrapper.type();
    const expected = 'div';
    expect(actual).toEqual(expected);
  });
});
