import React from 'react';
import { shallow } from 'enzyme';
import Title from './Title';
import { PLACE } from '../../actions/constants';

const id = 123;
const urlPart = '/Series/';
const props = {
  title: 'TitleTests'
};

describe('<Title />', () => {
  it('should be an h2 element', () => {
    const wrapper = shallow(<Title {...props} />);
    expect(wrapper.type()).toEqual('h2');
  });
  it('should return title from props', () => {
    const wrapper = shallow(<Title {...props} />);
    expect(wrapper.find('h2').text()).toEqual(props.title);
  });
  it('should return title and link from props with home place', () => {
    const wrapper = shallow(<Title {...props} place={PLACE.HOME} seriesId={id} />);
    expect(wrapper.find('h2').text()).toEqual(props.title);
    expect(wrapper.find('h2 a').prop('href')).toEqual(urlPart + id);
  });
  it('should return title and link from props with series place', () => {
    const wrapper = shallow(<Title {...props} place={PLACE.SERIES} id={id} />);
    expect(wrapper.find('h2').text()).toEqual(props.title);
    expect(wrapper.find('h2 a').prop('href')).toEqual(urlPart + id);
  });
});
