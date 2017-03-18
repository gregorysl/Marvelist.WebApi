import React from 'react';
import { shallow } from 'enzyme';
import ComicCount from './ComicCount';

describe('<ComicCount />', () => {
  it('should be an div element', () => {
    const props = {
      count: 5
    };
    const wrapper = shallow(<ComicCount {...props} />);
    expect(wrapper.type()).toEqual('div');
  });
  it('should return good number', () => {
    const props = {
      count: 5
    };
    const wrapper = shallow(<ComicCount {...props} />);
    expect(wrapper.find('div').text()).toEqual("5");
  });
  it('should be null without props', () => {
    const wrapper = shallow(<ComicCount />);
    expect(wrapper.type()).toEqual(null);
  });
});
